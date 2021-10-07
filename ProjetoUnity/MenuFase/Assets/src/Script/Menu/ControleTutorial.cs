using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleTutorial : MonoBehaviour
{
    public bool fezTutorial = false;

    private static ControleTutorial instancia;

    void Awake()
    {
        if(instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instancia != this)
        {
            Destroy(gameObject);
        }
    }
}