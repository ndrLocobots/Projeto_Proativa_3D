using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
  public Slider height, env, velocity;
  public Text Theight, Tenv, Tvelocity;
  public GameObject menu;

  QuedaAnimationControl animationControl;
  CuboQue cuboQue;

  [SerializeField]
  private QuestionQueda question;

  void Start()
  {
    cuboQue = FindObjectOfType<CuboQue>();
    animationControl = FindObjectOfType<QuedaAnimationControl>();
  }

  public void StartButton()
  {
    cuboQue.isJump = true;
    float[] userAnswers;

    if(velocity.gameObject.activeSelf)
      userAnswers = new float[3] {(float)height.value, (float)env.value, (float)velocity.value};
    else
      userAnswers = new float[2] {(float)height.value, (float)env.value};
    
    animationControl.isQuestionRight(userAnswers);
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
    Theight.text = "Altura: " + h + " m";
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

  public void SetVelocity(float v)
  {
    velocity.value = v;
    Tvelocity.text = "Velocidade: " + v + " m/s";
  }
}
