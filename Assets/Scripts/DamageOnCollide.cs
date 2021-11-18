using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollide : MonoBehaviour
{
    public int damage = 1;

    public int damageToSelf = 5;

    private void HitObject(GameObject theObject)
    {
        // The space staion included
        var theirDamage = theObject.GetComponentInParent<DamageTaking>();
        if (theirDamage)
        {
            theirDamage.TakeDamage(damage);
        }

        var ourDamage = this.GetComponentInParent<DamageTaking>();

        if (ourDamage)
        {
            Debug.Log($"{ourDamage.name} Damage To Self");
            ourDamage.TakeDamage(damageToSelf);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.gameObject.name} trigger");
        HitObject(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"{collision.gameObject.name} collision");
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
