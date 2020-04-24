﻿using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float moveSpeed = 5f;
    private GoldNugget goldScript;
    public float maxHold = 0f;

    private GameObject magnetpoint;
    private MagnetPoint margnetPointScript;

    // Start is called before the first frame update
    private void Start()
    {
        magnetpoint = GameObject.Find("MagnetPoint");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        transform.Translate(movement * Time.deltaTime * moveSpeed);

        /*if (maxHold >= 6f)
        {
            margnetPointScript = magnetpoint.GetComponent<MagnetPoint>();
            margnetPointScript.sphere.enabled = false;
        }
        */


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Gold")
        {
            goldScript = collision.gameObject.GetComponent<GoldNugget>();

            //goldScript.rb.constraints = RigidbodyConstraints.FreezeAll;

            maxHold = maxHold + goldScript.count;
            goldScript.isActive = false;

        }
    }


}