using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeapons : MonoBehaviour
{
    public GameObject shotPrefab;

    public Transform[] firePoints;

    private int firePointIndex;

    public void Awake()
    {
        InputManager.Instance.SetWeapons(this);
    }

    public void OnDestroy()
    {
        if (Application.isPlaying)
        {
            InputManager.Instance?.RemoveWeapons(this);
        }
    }

    public void Fire()
    {
        if (firePoints.Length == 0)
        {
            return;
        }

        var firePointToUse = firePoints[firePointIndex];

        Instantiate(shotPrefab, firePointToUse.position, firePointToUse.rotation);

        var audio = firePointToUse.GetComponent<AudioSource>();

        if (audio)
        {
            audio.Play();
        }

        firePointIndex++;

        if (firePointIndex >= firePoints.Length)
        {
            firePointIndex = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
