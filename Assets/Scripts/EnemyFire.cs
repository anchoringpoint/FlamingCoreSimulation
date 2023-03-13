using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyFire : MonoBehaviour
{
    public GameObject firePrefab;
    public float fireRate = 1f;
    private Transform firePoint;

    private void Start()
    {
        firePoint = this.gameObject.transform;
        InvokeRepeating("Fire", 0f, fireRate);

        
    }

    private void FixedUpdate()
    {

        
    }

    void Fire()
    {
        Debug.Log("Fire");
        GameObject fire = Instantiate(firePrefab, firePoint.position, firePoint.rotation);
        fire.GetComponent<Rigidbody>().velocity = fire.transform.forward * 10;
        if(this.gameObject.activeSelf==false)
        {
            Debug.Log("Cancel");
            CancelInvoke("Fire");
        }
    }
}
