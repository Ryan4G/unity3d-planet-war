using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollide : MonoBehaviour
{
    public int damage = 1;

    public int damageToSelf = 5;

    private void HitObject(GameObject theObject)
    {
        var theirDamage = theObject.GetComponent<DamageTaking>();
        if (theirDamage)
        {
            theirDamage.TakeDamage(damage);
        }

        var ourDamage = this.GetComponentInParent<DamageTaking>();

        if (ourDamage)
        {
            ourDamage.TakeDamage(damageToSelf);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        HitObject(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        HitObject(collision.gameObject);
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
