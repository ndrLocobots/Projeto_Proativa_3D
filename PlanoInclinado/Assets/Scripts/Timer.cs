using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float start;
    private bool isStarted;
    string minutes;
    string seconds;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Start"))
        {
            isStarted = true;

            start = Time.time;
        }
            
        if (other.CompareTag("End"))
        {
            isStarted = false;
        }
            
    }

    void Start()
    {
        start = Time.time;
    }

    void Update()
    {
        if(isStarted)
        {
            float t = Time.time - start;
            minutes = ((int)t / 60).ToString();
            seconds = (t % 60).ToString("f2");

            timerText.text = "Tempo: " + minutes + ":" + seconds;

            //Imprimir os valores;
        }
        
     }
}
