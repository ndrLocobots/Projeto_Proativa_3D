using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotClick : MonoBehaviour
{
  bool mouseOnCollider = false;

  void Update()
  {
    if (mouseOnCollider)
    {
      if (Input.GetMouseButtonDown(0))
      {
        GetComponent<dialog>().Talk();
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
