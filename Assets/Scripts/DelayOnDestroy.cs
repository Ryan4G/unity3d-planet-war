using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayOnDestroy : MonoBehaviour
{
    public float lifeTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
