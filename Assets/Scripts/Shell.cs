using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.position = new Vector3(0.88f, 2.39f, 0.3f);
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        if(!other.gameObject.CompareTag("Enemy"))
            Destroy(this.gameObject);
    }
}
