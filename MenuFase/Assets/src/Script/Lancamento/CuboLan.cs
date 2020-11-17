using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CuboLan : MonoBehaviour
{
  Rigidbody body;
  public GameObject panel;
  ScreenResults script;
  Vector3 startingPosition;

  bool isJumper, isEnemy;

  private Altar altar;
  private Tutorial tutorial;
  private BotaoStart botaoStart;

  void Start()
  {
    script = GetComponent<ScreenResults>();

    altar = FindObjectOfType<Altar>();

    body = GetComponent<Rigidbody>();

    tutorial = FindObjectOfType<Tutorial>();

    botaoStart = FindObjectOfType<BotaoStart>();

    body.freezeRotation = true;

    isJumper = isEnemy = false;

    startingPosition = body.position;
    panel.SetActive(false);
  }

  public void ClickStart(bool b)
  {
    if (body.velocity.magnitude == 0 && !isJumper)
    {
      if(!tutorial.isTutorial)
      {
        if(botaoStart.getPrimeiroExercicio())
        {
          botaoStart.exibeConfirmacao();
        }
        else
        {
          body.velocity = script.SetUserVelocity();
          isJumper = isEnemy = true;
        }
      }
      else
      {
        body.velocity = script.SetUserVelocity();
        isJumper = isEnemy = true;
      }
    }
  }

  public void ClickRestore(bool b)
  {
    this.gameObject.SetActive(true);
    body.velocity = new Vector3(0, 0, 0);
    body.position = startingPosition;
    isJumper = isEnemy =false;
    panel.SetActive(false);
  }

  public void AnimationConfig(){
    panel.SetActive(false);
    isJumper = isEnemy = false;
  }
  
  private void OnCollisionEnter(Collision collision)
  {
    if (isJumper)
    {
      body.velocity = new Vector3(0, 0, 0);
      script.SetOutputParam();
      panel.SetActive(true);
    }

    if (isEnemy){
      isEnemy = false; 
      GetComponent<QuestionAnimation>().isQuestionRight();
    }

  }

  //Detecta se o cubo entrou dentro da area de sucesso do altar (TriggerColisao)
  private void OnTriggerEnter(Collider col)
  {
    if(col.gameObject.tag == "Altar")
    {
      altar.setAtingido(true);
    }
  }

}
