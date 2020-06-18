using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuScript : MonoBehaviour
{
  bool active = true;

  public void UpdatePanel()
  {
    gameObject.SetActive(active);
    active = !active;
  }

}
