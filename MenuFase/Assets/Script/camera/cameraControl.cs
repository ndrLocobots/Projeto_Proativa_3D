using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
  public GameObject robot;
  private float robotXPosition;
  private bool isMenu = false;
  private bool isTalk = false;

  private bool isClick = false;
  void Start()
  {
    robotXPosition = robot.GetComponent<Transform>().position.x;
  }

  void Update()
  {
    isTalk = robot.GetComponent<robotAnimation>().isTalk;

    if (!isMenu && !isTalk && !isClick)
    {
      GetComponent<rotation>().LookWithMouse();
    }
    else{
      GetComponent<rotation>().DontLook();
    }

    if (Input.GetKeyDown(KeyCode.M))
    {
      isMenu = !isMenu;
    }

    if (Input.GetMouseButtonDown(0)){
      isClick = isMenu ? false : !isClick;
    }

    if(isTalk){
       GetComponent<position>().SliderAux(0);
       GetComponent<rotation>().LookForRobot();
    }
  }
}
