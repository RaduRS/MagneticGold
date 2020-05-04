using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text text;
    public float scoreText;

    // Update is called once per frame
    void Update()
    {
        text.text = scoreText.ToString();
    }
}
