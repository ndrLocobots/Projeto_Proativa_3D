using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
  public GameObject robot;
  public GameObject scenaMenu;
  private bool isTalk = false;

  void Update()
  {
    isTalk = robot.GetComponent<dialog>().isTalk;
    
    if(isTalk){
       GetComponent<position>().SliderAux(0);  
    }
  }
}
