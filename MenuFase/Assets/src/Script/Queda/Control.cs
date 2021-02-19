using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
  public Slider height, env;
  public Text Theight, Tenv;
  public GameObject menu;

  CuboQue cuboQue;

  void Start()
  {
    cuboQue = FindObjectOfType<CuboQue>();
  }

  public void StartButton(bool b)
  {
    cuboQue.isJump = true;
  }

  public void RestartButton(bool b)
  {
    height.value = 0;
    env.value = 1;

    cuboQue.SetHeight(0);
    cuboQue.SetEnvironment(1);

    cuboQue.Restart();
  }

  public void SetMenu(){
    menu.SetActive(!menu.activeSelf);

    if(menu.activeSelf){
      cuboQue.result.SetActive(false);
    }
  }

  public void SetHeight(float h)
  {
    cuboQue.SetHeight(h);
    Theight.text = "Altura: " + h;
  }

  public void SetEnvironment(float a)
  {
    cuboQue.SetEnvironment(a);
    height.value = 0;
    Tenv.text = "Ambiente: " + a;
  }
}
