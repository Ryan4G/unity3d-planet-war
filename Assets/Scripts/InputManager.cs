using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public VirtualJoystick steering;

    public float fireRate = .2f;

    private ShipWeapons currentWeapons;

    private bool isFiring = false;

    public void SetWeapons(ShipWeapons weapons)
    {
        this.currentWeapons = weapons;
    }

    public void RemoveWeapons(ShipWeapons weapons)
    {
        if (weapons == this.currentWeapons)
        {
            this.currentWeapons = null;
        }
    }

    public void StartFiring()
    {
        StartCoroutine(FireWeapons());
    }

    IEnumerator FireWeapons()
    {
        isFiring = true;

        while (isFiring)
        {
            if (this.currentWeapons != null)
            {
                this.currentWeapons.Fire();
            }

            yield return new WaitForSeconds(fireRate);
        }
    }

    public void StopFiring()
    {
        isFiring = false;
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
