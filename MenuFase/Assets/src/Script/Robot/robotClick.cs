using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class robotClick : MonoBehaviour
{
  bool mouseOnCollider = false;

  public Button botaoStart;
  public Button botaoMenu;

  void Update()
  {
    if (mouseOnCollider)
    {
      if (Input.GetMouseButtonDown(0))
      {
        GetComponent<dialog>().Talk();
        botaoStart.interactable = true;
        botaoMenu.interactable = true;
      }
    }
  }

  void OnMouseEnter()
  {
    mouseOnCollider = true;
  }

  void OnMouseExit()
  {
    mouseOnCollider = false;
  }
}
