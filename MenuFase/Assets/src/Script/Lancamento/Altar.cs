using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : MonoBehaviour
{
    private bool fuiAtingido;
    public Animator animAltar;

    void Start()
    {
        fuiAtingido = false;
    }
    void Update()
    {
        if(fuiAtingido)
        {
            animAltar.SetBool("FuiAtingido", true);
            fuiAtingido = false;
        }
    }
    public void setAtingido()
    {
        this.fuiAtingido = true;
    }
   
    public bool getFuiAtingido()
    {
        return this.fuiAtingido;
    }
}
