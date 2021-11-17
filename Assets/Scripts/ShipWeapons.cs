using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeapons : MonoBehaviour
{
    public GameObject shotPrefab;

    public Transform[] firePoints;

    private int firePointIndex;

    public void Fire()
    {
        if (firePoints.Length == 0)
        {
            return;
        }

        var firePointToUse = firePoints[firePointIndex];

        Instantiate(shotPrefab, firePointToUse.position, firePointToUse.rotation);

        firePointIndex++;

        if (firePointIndex >= firePoints.Length)
        {
            firePointIndex++;
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
