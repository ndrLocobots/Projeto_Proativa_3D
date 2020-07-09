using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
  RectTransform arrowTransform;
  public GameObject arrow;
  public GameObject[] objectsCena;

  public int index;
  int veloIndex, angleIndex, menuIndex, startIndex, restoreIndex, nextIndex;

  public bool isTutorial = false;
  bool wasPressStart = false;

  void Start()
  {
    arrowTransform = arrow.GetComponent<RectTransform>();
    arrow.SetActive(false);

    index = 0;
    menuIndex = 0;
    angleIndex = 1;
    veloIndex = 2;
    startIndex = 3;
    restoreIndex = 4;
    nextIndex = 5;
  }

  public void StartTutorial()
  {
    isTutorial = true;
    arrow.SetActive(true);
  }

  void Update()
  {

    if (isTutorial || index == nextIndex)
    {
      ShowTheObjectsCena();

      if (index == angleIndex)
      {
        SliderAngleAvaliable();
      }
      else if (index == veloIndex)
      {
        SliderVelocityAvaliable();
      }
      else if (wasPressStart && index == startIndex)
      {
        index = restoreIndex;
      }
    }
  }

  void ShowTheObjectsCena()
  {
    RectTransform transform = objectsCena[index].GetComponent<RectTransform>();
    float corretionFacto = 0.76f; // tive que usar o fator de coreçao devido aos componentes não estarem em posição diferente

    if (index == menuIndex)
    {
      corretionFacto = 0.90f;
    }
    else if(index == restoreIndex){
      corretionFacto = 0.85f;
    }
    else if(index == nextIndex){
      corretionFacto = 0.92f;
    }

    arrowTransform.position = new Vector3(
      transform.position.x * corretionFacto,
      transform.position.y,
      transform.position.z
    );
  }

  void SliderVelocityAvaliable()
  {
    Slider velocity = objectsCena[index].GetComponent<Slider>();

    if (velocity.value > 5)
    {
      index++;
    }
  }

  void SliderAngleAvaliable()
  {
    Slider angle = objectsCena[index].GetComponent<Slider>();

    if (angle.value > 5)
    {
      index++;
    }
  }

  public void PressButtonMenu()
  {
    if (index == menuIndex && isTutorial)
    {
      index++;
    }
  }

  public void PressButtonStart()
  {
    if (index == startIndex && !wasPressStart)
    {
      index = 0;
      wasPressStart = true;
    }
  }

  public void PressButtonRestore()
  {
    if (index == restoreIndex && wasPressStart)
    {
      wasPressStart = isTutorial = false;
      index++;
    }
  }

  public void PressNextIndex()
  {
    if (index == nextIndex)
    {
      arrow.SetActive(false);
    }
  }
}
