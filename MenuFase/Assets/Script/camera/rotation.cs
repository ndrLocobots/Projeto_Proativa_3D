using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
  // Start is called before the first frame update
  public float sensibilidade = 2.0f;
  private Transform positionCamera;
  private float mouseX = 0.0f, mouseY = 0.0f;
  private bool isMenu = false;
  void Start()
  {
    positionCamera = GetComponent<Transform>();

    //Cursor.visible = true;
    Cursor.lockState = CursorLockMode.Locked;
  }


  void Update()
  {
    if (!isMenu)
    {
      Cursor.lockState = CursorLockMode.Locked;
      mouseX += Input.GetAxis("Mouse X") * sensibilidade;
      mouseY -= Input.GetAxis("Mouse Y") * sensibilidade;
      positionCamera.eulerAngles = new Vector3(mouseY, mouseX, 0);
    }

    if (Input.GetKeyDown(KeyCode.M))
    {
      Cursor.visible = true;
      Cursor.lockState = CursorLockMode.None;
      isMenu = !isMenu;
    }
  }
}
