using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class robotClick : MonoBehaviour
{
  bool mouseOnCollider = false;

  private heart hearts;

  public GameObject timer;
  public Button botaoStart;
  public Button botaoMenu;

  void Awake()
  {
    hearts = FindObjectOfType<heart>();
  }

  void Update()
  {
    if (mouseOnCollider)
    {
      if (Input.GetMouseButtonDown(0))
      {
        GetComponent<dialog>().Talk();
        botaoStart.interactable = true;
        botaoMenu.interactable = true;

        //gambiarra temporaria
        if(SceneManager.GetActiveScene().name == "Plano")
        {
          hearts.updateOpacityHearts(1);
          timer.GetComponent<Text>().enabled = true;
        }
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
