using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour
{
    public Text score;
    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score: " + PlayerPrefs.GetInt("score").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
