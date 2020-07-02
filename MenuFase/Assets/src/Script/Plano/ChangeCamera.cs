using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject camera01;
    public GameObject camera02;
    public GameObject camera03;

    public void SelectCamera(float value)
    {
        if (value == 0)
        {
            camera01.SetActive(true);
            camera02.SetActive(false);
            camera03.SetActive(false);
        }
        if (value == 1)
        {
            camera01.SetActive(false);
            camera02.SetActive(true);
            camera03.SetActive(false);
        }
        if (value == 2)
        {
            camera01.SetActive(false);
            camera02.SetActive(false);
            camera03.SetActive(true);
        }
    }
}
