﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt : MonoBehaviour
{
    public GameObject belt;
    public Transform endpoint;
    public float speed;
    private float beltSpeed = 500f;


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Gold"))
        {
            other.transform.position = Vector3.MoveTowards(other.transform.position, endpoint.position, speed * Time.deltaTime);
            other.attachedRigidbody.AddForce(0f, beltSpeed, 0f);
        }
    }
}
