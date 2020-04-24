using UnityEngine;

public class GoldNugget : MonoBehaviour
{
    public Rigidbody rb;
    public int count = 1;
    public bool isActive = true;
    public bool isTouching = true;

    // Update is called once per frame
    private void Update()
    {
        rb.AddForce(Physics.gravity * 2f, ForceMode.Acceleration);

        if (isActive == false)
        {
            count = 0;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Magnet")
        {
            isActive = false;
            count = 0;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Magnet")
        {
            isTouching = false;
        }
        else
        {
            isTouching = true;
        }
    }

    //on collisition enter and if is touching is false, 
}