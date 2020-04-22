using UnityEngine;

public class GoldNugget : MonoBehaviour
{
    public Rigidbody rb;

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Physics.gravity * 2f, ForceMode.Acceleration);
    }
}
