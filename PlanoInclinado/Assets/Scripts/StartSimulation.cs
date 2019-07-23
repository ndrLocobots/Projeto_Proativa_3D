using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSimulation : MonoBehaviour
{
    public void Start()
    {
        Time.timeScale = 0;
    }
    
    public void StartSim()
    {
        Time.timeScale = 1;
    }
}
