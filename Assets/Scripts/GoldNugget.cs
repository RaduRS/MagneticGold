using UnityEngine;

public class GoldNugget : MonoBehaviour
{
    public Rigidbody rb;
    public int count = 1;
    public bool isActive = true;
    public bool isTouching = true;
    public bool groundTouch = false;
    public Magnet magnetScript;
    public GameObject magnet;

    // Update is called once per frame

    private void Start()
    {
        magnet = GameObject.Find("Magnet");
        magnetScript = magnet.GetComponent<Magnet>();

        

    }
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
            isTouching = true;
        }

        if(collision.gameObject.tag == "Ground")
        {
            isTouching = false;
            count = 1;
            magnetScript.maxHold = magnetScript.maxHold - 1;
        }
    }

    //on collisition enter and if is touching is false, 
}