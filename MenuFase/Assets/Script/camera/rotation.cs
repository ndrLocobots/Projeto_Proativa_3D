using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
  // Start is called before the first frame update

  public GameObject robot;
  private Transform positionCamera;
  public float sensibilidade = 2.0f;
  private float mouseX = 0.0f, mouseY = 0.0f;
  private bool isMenu = false;
  private bool isTalk = false;
  void Start()
  {
    positionCamera = GetComponent<Transform>();

    //Cursor.visible = true;
    Cursor.lockState = CursorLockMode.Locked;
  }


  void Update()
  {
    isTalk = robot.GetComponent<robotAnimation>().isTalk;
    if (!isMenu && !isTalk)
    {
      mouseX += Input.GetAxis("Mouse X") * sensibilidade;
      mouseY -= Input.GetAxis("Mouse Y") * sensibilidade;
      positionCamera.eulerAngles = new Vector3(mouseY, mouseX, 0);
      Cursor.lockState = CursorLockMode.Locked;

    }
    else
    {
      Cursor.visible = true;
      Cursor.lockState = CursorLockMode.None;
    }

    if (Input.GetKeyDown(KeyCode.M) || Input.GetMouseButtonDown(0))
    {
      isMenu = !isMenu;
    }
  }

  public void LookWithMouse()
  {
    mouseX += Input.GetAxis("Mouse X") * sensibilidade;
    mouseY -= Input.GetAxis("Mouse Y") * sensibilidade;
    positionCamera.eulerAngles = new Vector3(mouseY, mouseX, 0);
    Cursor.lockState = CursorLockMode.Locked;
  }

  public void DontLook()
  {
    Cursor.visible = true;
    Cursor.lockState = CursorLockMode.None;
  }


}
