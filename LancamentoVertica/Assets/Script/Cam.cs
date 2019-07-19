﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform per;
    public Transform cam;
    public int aux;
    // Start is called before the first frame update
    void Start()
    {
        aux = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (aux)
        {
            case 0:
                cam.rotation = Quaternion.Euler(0, 270, 0);
                cam.position = new Vector3(per.position.x, per.position.y + 1, per.position.z);
                break;
            case 1:
                cam.rotation = Quaternion.Euler(25, 270, 0);
                cam.position = new Vector3(per.position.x + 10, per.position.y + 10, per.position.z);
                break;
            case 2:
                cam.rotation = Quaternion.Euler(25, 360, 0);
                cam.position = new Vector3(per.position.x, per.position.y + 10, per.position.z - 24);
                break;
            default:
                aux = 0;
                break;

        }
        
    }
}
