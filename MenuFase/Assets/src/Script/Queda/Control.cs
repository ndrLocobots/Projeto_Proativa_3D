using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
  public Slider height, env;
  public Text Theight, Tenv;
  public GameObject menu;

  QuedaAnimationControl animationControl;
  CuboQue cuboQue;

  void Start()
  {
    cuboQue = FindObjectOfType<CuboQue>();
    animationControl = FindObjectOfType<QuedaAnimationControl>();
  }

  public void StartButton()
  {
    cuboQue.isJump = true;

    float time = cuboQue.CalculateValue(
      height.value,
      (int)env.value
    );

    animationControl.isQuestionRight(time);
  }

  public void RestartButton()
  {
    height.value = 0;
    cuboQue.SetHeight(0);
    cuboQue.Restore();
  }

  public void SetMenu()
  {
    menu.SetActive(!menu.activeSelf);

    if (menu.activeSelf)
    {
      cuboQue.result.SetActive(false);

      SetHeight(height.value);
    }
  }

  public void SetHeight(float h)
  {
    cuboQue.SetHeight(h);
    height.value = h;
    Theight.text = "Altura: " + h;
  }

  public void SetEnvironment(float a)
  {
    cuboQue.SetEnvironment(a);
    switch (a)
    {
      case 0:
        Tenv.text = "Gravidade: " + 20 + " m/s²";
        break;

      case 1:
        Tenv.text = "Gravidade: " + 10 + " m/s²";
        break;

      case 2:
        Tenv.text = "Gravidade: " + 3 + " m/s²";
        break;
    }
  }
}
