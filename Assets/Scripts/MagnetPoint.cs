using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPoint : MonoBehaviour
{
    public float forceFactor = 0f;
    public SphereCollider sphere;
    List<Rigidbody> rbGoldNuggets = new List<Rigidbody>();

    Transform magnetPoint;

    public bool isMagnetized = false;

    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        magnetPoint = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        foreach (Rigidbody rbGold in rbGoldNuggets)
        {
            rbGold.AddForce((magnetPoint.position + offset - rbGold.position) * forceFactor * Time.fixedDeltaTime);
        }
    }

    private void Update()
    {
        if (isMagnetized == true && Input.GetMouseButtonUp(0))
        {
            isMagnetized = false;
            forceFactor = 0f;
        }
        else if (isMagnetized == false && forceFactor == 0f && Input.GetMouseButtonDown(0))
        {
            isMagnetized = true;
            forceFactor = 25000f;
        }
        else if (isMagnetized == true && forceFactor == 0f && Input.GetMouseButtonDown(0))
        {
            forceFactor = 25000f;
        }
        else if (isMagnetized == false)
        {
            forceFactor = 0f;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gold"))
        {
            isMagnetized = true;
            rbGoldNuggets.Add(other.GetComponent<Rigidbody>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Gold"))
        {
            rbGoldNuggets.Remove(other.GetComponent<Rigidbody>());
        }
    }


}
