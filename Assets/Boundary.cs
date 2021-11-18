using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    public float warningRadius = 400f;

    public float destroyRadius = 450f;

    public void OnDrawGizmosSelected()
    {
        // warning zone
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(transform.position, warningRadius);

        // destory zone
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, destroyRadius);
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
