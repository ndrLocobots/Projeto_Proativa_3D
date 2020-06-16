﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotClick : MonoBehaviour
{
    Animator robotAnimator;
    public GameObject robot;
    bool mouseOnCollider = false;
    void Start()
    {
        robotAnimator = robot.GetComponent<robotAnimation>().robotAnimator;
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseOnCollider){
          if(Input.GetMouseButtonDown(0)){
            robotAnimator.SetBool("isTalk", true);
          }
        }
    }

    void OnMouseEnter(){
      mouseOnCollider = true;
    }

    void OnMouseExit(){
      mouseOnCollider = false;
    }
}
