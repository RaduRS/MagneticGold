using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMagnet : MonoBehaviour
{

    public Transform magnet;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = magnet.position + offset;
    }
}
