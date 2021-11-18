using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodSpwaner : MonoBehaviour
{
    public float radius = 250.0f;

    public Rigidbody asteriodPrefab;

    public float spwanRate = 5.0f;

    public float variance = 1.0f;

    public Transform target;

    public bool spwanAsteriods = false;

    public int maxAsteriods = 5;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateAsteriods());    
    }

    IEnumerator CreateAsteriods()
    {
        while (true)
        {
            float nextSpwanTtime = spwanRate + Random.Range(-variance, variance);

            yield return new WaitForSeconds(nextSpwanTtime);

            yield return new WaitForFixedUpdate();

            if (GameManager.Instance.asteroids.Count < maxAsteriods)
            {
                CreateNewAsteriods();
            }
        }
    }

    private void CreateNewAsteriods()
    {
        if (!spwanAsteriods)
        {
            return;
        }

        var asteriodPosition = Random.onUnitSphere * radius;

        asteriodPosition.Scale(transform.lossyScale);

        asteriodPosition += transform.position;

        var newAsteriod = Instantiate(asteriodPrefab);

        newAsteriod.transform.position = asteriodPosition;

        newAsteriod.transform.LookAt(target);

        GameManager.Instance.asteroids.Add(newAsteriod.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        Gizmos.matrix = transform.localToWorldMatrix;

        Gizmos.DrawWireSphere(Vector3.zero, radius);
    }

    public void DestoryAllAsteriods()
    {
        foreach(var asteriod in FindObjectsOfType<Asteroid>())
        {
            Destroy(asteriod.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
