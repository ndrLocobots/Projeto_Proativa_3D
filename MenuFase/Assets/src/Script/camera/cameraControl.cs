using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
  public GameObject robot;
  public GameObject scenaMenu;

  private bool isTalk = false;

  Animation cameraAnimation;

  void Start()
  {
    cameraAnimation = GetComponent<Animation>();
  }

  void Update()
  {
    isTalk = robot.GetComponent<dialog>().isTalk;

    if (isTalk)
    {
      GetComponent<position>().SliderAux(0);
    }
  }

  public void AnimatorCamera()
  {
    if (cameraAnimation)
    {
      cameraAnimation.Play();
    }
  }
}
