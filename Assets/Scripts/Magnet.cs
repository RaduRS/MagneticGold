using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float moveSpeed = 5f;
    private GoldNugget goldScript;
    public float maxHold = 0f;
    public bool maxReached = false;

    private GameObject magnetpoint;
    private MagnetPoint margnetPointScript;

    // Start is called before the first frame update
    private void Start()
    {
        magnetpoint = GameObject.Find("MagnetPoint");
        margnetPointScript = magnetpoint.GetComponent<MagnetPoint>();
    }


    private void Update()
    {
        /*
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 30f;
            margnetPointScript.forceFactor = 50000f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 10f;
        }
        */
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);

        transform.Translate(movement * Time.deltaTime * moveSpeed);

        if(maxHold == 6)
        {
            maxReached = true;
        } else if (maxHold < 6)
        {
            maxReached = false;
        }

        if(maxHold <= 0)
        {
            maxHold = Mathf.Clamp(maxHold, 0, Mathf.Infinity);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Gold")
        {
            goldScript = collision.gameObject.GetComponent<GoldNugget>();

            maxHold = maxHold + goldScript.count;
            goldScript.isActive = false;

        }
    }


}