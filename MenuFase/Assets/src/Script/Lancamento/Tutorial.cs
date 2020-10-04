using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
  public GameObject arrow;

  public GameObject menuButton, startButton, restoreButton, nextButton, velocitySlider, cameraSlider, angleSlider;

  dialog robotDialog;

  public int index;
  public bool isTutorial = false;

  void Start()
  {
    robotDialog = FindObjectOfType<dialog>();
    arrow.SetActive(false);
  }

  public void StartTutorial()
  {
    isTutorial = true;
    index = -1;
    arrow.SetActive(true);
  }

  void Update()
  {
    if (isTutorial)
    {
      if (index == -1)
      {
        Button button = menuButton.GetComponent<Button>();
        button.onClick.AddListener(delegate { this.FirstPressButtonMenu(); });

        PositionArrowObjectInCena(menuButton, 0.90f);
        index++;
      }
      else if (index == 1)
      {
        SliderCameraAvaliable();
      }
      else if (index == 2)
      {
        SliderAngleAvaliable();
      }
      else if (index == 3)
      {
        SliderVelocityAvaliable();
      }
    }
  }

  void PositionArrowObjectInCena(GameObject gameObject, float corretionFacto)
  {
    RectTransform transform = gameObject.GetComponent<RectTransform>();
    RectTransform arrowTransform = arrow.GetComponent<RectTransform>();

    arrowTransform.position = new Vector3(
      transform.position.x * corretionFacto,
      transform.position.y,
      transform.position.z
    );
  }

  public void FirstPressButtonMenu()
  {
    Button button = menuButton.GetComponent<Button>();
    button.onClick.RemoveListener(delegate { this.FirstPressButtonMenu(); });

    index++;
    robotDialog.StopTalk();

    PositionArrowObjectInCena(cameraSlider, 0.76f);
  }

  void SliderCameraAvaliable()
  {
    Slider camera = cameraSlider.GetComponent<Slider>();

    if (camera.value >= 1)
    {
      index++;
      PositionArrowObjectInCena(angleSlider, 0.76f);
    }
  }

  void SliderAngleAvaliable()
  {
    Slider angle = angleSlider.GetComponent<Slider>();

    if (angle.value > 5)
    {
      index++;
      PositionArrowObjectInCena(velocitySlider, 0.76f);
    }
  }

  void SliderVelocityAvaliable()
  {
    Slider velocity = velocitySlider.GetComponent<Slider>();

    if (velocity.value > 5)
    {
      index++;
      Button button = startButton.GetComponent<Button>();
      button.onClick.AddListener(delegate { this.PressButtonStart(); });

      PositionArrowObjectInCena(startButton, 0.76f);
    }
  }

  public void PressButtonStart()
  {
    Button button = startButton.GetComponent<Button>();
    button.onClick.RemoveListener(delegate { this.PressButtonStart(); });

    index++;

    button = menuButton.GetComponent<Button>();
    button.onClick.AddListener(delegate { this.SecondPressButtonMenu(); });

    PositionArrowObjectInCena(menuButton, 0.90f);
  }

  void SecondPressButtonMenu()
  {
    Button button = menuButton.GetComponent<Button>();
    button.onClick.RemoveListener(delegate { this.SecondPressButtonMenu(); });

    index++;

    button = restoreButton.GetComponent<Button>();
    button.onClick.AddListener(delegate { this.PressButtonRestore(); });

    PositionArrowObjectInCena(restoreButton, 0.85f);
  }

  public void PressButtonRestore()
  {
    Button button = restoreButton.GetComponent<Button>();
    button.onClick.RemoveListener(delegate { this.PressButtonRestore(); });

    isTutorial = false;
    robotDialog.Talk();
    index++;

    button = nextButton.GetComponent<Button>();
    button.onClick.AddListener(delegate { this.PressNextIndex(); });

    PositionArrowObjectInCena(nextButton, 0.92f);
  }

  public void PressNextIndex()
  {
    Button button = nextButton.GetComponent<Button>();
    button.onClick.RemoveListener(delegate { this.PressNextIndex(); });

    arrow.SetActive(false);
  }
}
