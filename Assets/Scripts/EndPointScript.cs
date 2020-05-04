using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointScript : MonoBehaviour
{
    public GameObject text;
    public Score scoreScript;


    private void Start()
    {
        text = GameObject.Find("Text");
        scoreScript = text.GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gold"))
        {
            scoreScript.scoreText = scoreScript.scoreText + 1;
        }
    }
}
