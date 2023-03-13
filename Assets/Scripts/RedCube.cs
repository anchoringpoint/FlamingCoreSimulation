using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCube : MonoBehaviour
{
    public GameObject _ball;
    private void OnTriggerEnter(Collider other)
    {
        _ball.transform.position = new Vector3(0.88f, 2.39f, 0.3f);
        _ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
