using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
  public GameObject arrow;
  public GameObject[] objectsCena;

  dialog robotDialog;

  public int index;
  int veloIndex, angleIndex, cameraIndex;
  int secondMenuIndex, firstMenuIndex;
  int startIndex, restoreIndex, nextIndex;

  public bool isTutorial = false;

  void Start()
  {
    robotDialog = FindObjectOfType<dialog>();

    arrow.SetActive(false);

    index = 0;
    firstMenuIndex = 0;
    cameraIndex = 1;
    angleIndex = 2;
    veloIndex = 3;
    startIndex = 4;
    secondMenuIndex = 5;
    restoreIndex = 6;
    nextIndex = 7;
  }

  public void StartTutorial()
  {
    isTutorial = true;
    index = 0;
    arrow.SetActive(true);
  }

  void Update()
  {

    if (isTutorial || index == nextIndex)
    {
      PositionArrowObjectInCena();

      if (index == cameraIndex)
      {
        SliderCameraAvaliable();
      }
      else if (index == angleIndex)
      {
        SliderAngleAvaliable();
      }
      else if (index == veloIndex)
      {
        SliderVelocityAvaliable();
      }
    }
  }

  void PositionArrowObjectInCena()
  {
    RectTransform transform = objectsCena[index].GetComponent<RectTransform>();
    RectTransform arrowTransform = arrow.GetComponent<RectTransform>();

    float corretionFacto = 0.76f; // tive que usar o fator de coreçao devido aos componentes não estarem em posição diferente

    if (index == firstMenuIndex || index == secondMenuIndex)
    {
      corretionFacto = 0.90f;
    }
    else if (index == restoreIndex)
    {
      corretionFacto = 0.85f;
    }
    else if (index == nextIndex)
    {
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

  void SliderCameraAvaliable()
  {
    Slider camera = objectsCena[index].GetComponent<Slider>();

    if (camera.value >= 1)
    {
      index++;
    }
  }

  public void PressButtonMenu()
  {
    if ((index == firstMenuIndex || index == secondMenuIndex) && isTutorial)
    {
      index++;
      robotDialog.StopTalk();
    }
  }

  public void PressButtonStart()
  {
    if (index == startIndex)
    {
      index++;
    }
  }

  public void PressButtonRestore()
  {
    if (index == restoreIndex)
    {
      isTutorial = false;
      robotDialog.Talk();
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
