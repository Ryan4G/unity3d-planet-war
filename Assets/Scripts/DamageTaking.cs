using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaking : MonoBehaviour
{
    public int hitPoints = 10;

    public GameObject destructionPrefab;

    public bool gameOverOnDestroyed = false;

    public void TakeDamage(int amount)
    {
        Debug.Log(gameObject.name + " damaged!");

        hitPoints -= amount;

        if (hitPoints <= 0)
        {
            Debug.Log(gameObject.name + " destroyed!");

            if (gameObject.tag.CompareTo("Asteroid") == 0)
            {
                GameManager.Instance.asteroids.Remove(gameObject);
            }

            Destroy(gameObject);

            if (destructionPrefab != null)
            {
                Instantiate(destructionPrefab, transform.position, transform.rotation);
            }

            if (gameOverOnDestroyed)
            {
                GameManager.Instance.GameOver();
            }
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
