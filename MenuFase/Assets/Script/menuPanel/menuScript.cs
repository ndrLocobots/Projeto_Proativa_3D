using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuScript : MonoBehaviour
{
    public GameObject panel;
    private bool active = true;
    void Start()
    {
    
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)){
          panel.SetActive(active);
          active = !active;
        }
    }
}
