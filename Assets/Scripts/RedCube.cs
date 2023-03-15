using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCube : MonoBehaviour
{
    public GameObject _ball;
   private void OnTriggerEnter(Collider other)
   {
       if (other.gameObject.CompareTag("Player"))
       {
           other.gameObject.transform.position = new Vector3(0.88f, 2.39f, 0.3f);
           other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
       }
   }
}
