using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float speed = 100.0f;

    public float life = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, life);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
