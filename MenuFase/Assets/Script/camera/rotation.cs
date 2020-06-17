using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
  private Transform ObjectCamera;
  public float sensibilidade = 2.0f;
  private float mouseX = 0.0f, mouseY = 0.0f;
  void Start()
  {
    ObjectCamera = GetComponent<Transform>();
    Cursor.lockState = CursorLockMode.Locked;
  }

  public void LookWithMouse()
  {
    mouseX += Input.GetAxis("Mouse X") * sensibilidade;
    mouseY -= Input.GetAxis("Mouse Y") * sensibilidade;
    ObjectCamera.eulerAngles = new Vector3(mouseY, mouseX, 0);
    Cursor.lockState = CursorLockMode.Locked;
  }

  public void DontLook()
  {
    Cursor.visible = true;
    Cursor.lockState = CursorLockMode.None;
  }

  public void LookForRobot(){
    ObjectCamera.eulerAngles = new Vector3(-4,90, 0);
  }


}
