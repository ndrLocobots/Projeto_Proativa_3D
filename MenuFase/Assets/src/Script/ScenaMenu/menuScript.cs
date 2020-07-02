using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuScript : MonoBehaviour
{
  bool active = true;
  public GameObject[] screenComponents;

  public void UpdatePanel()
  {
    gameObject.SetActive(active);
    active = !active;
    updateOtherScreenComponents(active);
  }

  void updateOtherScreenComponents(bool active)
  {
    for (int i = 0; i < screenComponents.Length - 1; i++)
    {
      try
      {
        screenComponents[i].SetActive(active);
      }
      catch (System.Exception)
      {

        Debug.Log("none screen component on menuScript");
      }
    }
  }


}
