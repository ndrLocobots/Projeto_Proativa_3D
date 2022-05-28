using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudaCamera : MonoBehaviour
{
    public GameObject camera01;
    public GameObject camera02;


    void Start()
    {
        camera01.SetActive(true);
        camera02.SetActive(false);
    }
    
    void Update()
    {
        
    }

    public void AtualizaCamera(float v)
    {
        if(v == 1)
        {
            camera01.SetActive(true);
            camera02.SetActive(false);
        }
        if(v == 2)
        {
            camera01.SetActive(false);
            camera02.SetActive(true);
        }
    }
}

