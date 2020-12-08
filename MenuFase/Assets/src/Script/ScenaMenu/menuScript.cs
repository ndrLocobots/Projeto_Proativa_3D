using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    for (int i = 0; i < screenComponents.Length; i++)
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

  public void ShowOpacityAnimationMenu(){
    StartCoroutine(ChangeOpacityMenu());
  }

  IEnumerator ChangeOpacityMenu(){
    Image image =  GetComponent<Image>();
    var tempColor = image.color;

    if (image){
      tempColor.a = 0.2f;
      image.color = tempColor;
      
      yield return new WaitForSeconds(0.6f);
      
      tempColor.a = 1f;
      image.color = tempColor;
    }
  }
}
