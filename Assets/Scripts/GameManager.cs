using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject shipPrefab;

    public Transform shipStartPosition;

    public GameObject currentShip
    {
        get;

        private set;
    }

    public GameObject spaceStationPrefab;

    public Transform spaceStationStartPosition;

    public GameObject currentSpaceStation
    {
        get;
        private set;
    }

    public SmoothFollow cameraFollow;

    public GameObject inGameUI;
    public GameObject pausedUI;
    public GameObject gameOverUI;
    public GameObject mainMenuUI;
    public GameObject warningUI;

    public Boundary boundary;

    public List<GameObject> asteroids;

    public bool gameIsPlaying
    {
        get;
        private set;
    }

    public AsteriodSpwaner asteriodSpwaner;

    public bool paused;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    private void ShowMainMenu()
    {
        ShowUI(mainMenuUI);

        gameIsPlaying = false;

        asteriodSpwaner.spwanAsteriods = false;

        asteroids = new List<GameObject>();
    }

    private void ShowUI(GameObject newUI)
    {
        GameObject[] allUI = { inGameUI, pausedUI, gameOverUI, mainMenuUI };

        foreach(var go in allUI)
        {
            go.SetActive(false);
        }

        newUI.SetActive(true);
    }

    public void StartGame()
    {
        ShowUI(inGameUI);

        gameIsPlaying = true;

        if (currentShip != null)
        {
            Destroy(currentShip);
        }

        if (currentSpaceStation != null)
        {
            Destroy(currentSpaceStation);
        }

        currentShip = Instantiate(shipPrefab, shipStartPosition.position, shipStartPosition.rotation);

        currentSpaceStation = Instantiate(spaceStationPrefab, spaceStationStartPosition.position, spaceStationStartPosition.rotation);

        cameraFollow.target = currentShip.transform;

        asteriodSpwaner.spwanAsteriods = true;

        asteriodSpwaner.target = currentSpaceStation.transform;
    }

    public void GameOver()
    {
        ShowUI(gameOverUI);

        gameIsPlaying = false;

        if (currentShip != null)
        {
            Destroy(currentShip);
        }

        if (currentSpaceStation != null)
        {
            Destroy(currentSpaceStation);
        }

        warningUI.SetActive(false);

        asteriodSpwaner.spwanAsteriods = false;

        asteriodSpwaner.DestoryAllAsteriods();
    }

    public void SetPaused(bool paused)
    {
        inGameUI.SetActive(!paused);

        pausedUI.SetActive(paused);

        if (paused)
        {
            Time.timeScale = 0f;
            currentShip.GetComponent<AudioSource>().mute = true;
        }
        else
        {
            Time.timeScale = 1f;
            currentShip.GetComponent<AudioSource>().mute = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentShip == null)
        {
            return;
        }

        float distance = (currentShip.transform.position - boundary.transform.position).magnitude;

        if (distance > boundary.destroyRadius)
        {
            GameOver();
        }
        else if (distance > boundary.warningRadius)
        {
            warningUI.SetActive(true);
        }
        else
        {
            warningUI.SetActive(false);
        }
    }
}
