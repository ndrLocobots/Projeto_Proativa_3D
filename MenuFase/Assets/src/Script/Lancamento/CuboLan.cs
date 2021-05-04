using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CuboLan : MonoBehaviour
{
  public GameObject painelResultados;

  private Rigidbody bodyCubo;
  private ScreenResults calculaResultados;
  private Vector3 startingPosition;

  private bool isJumper, isEnemy;
  private Teleporter altar;
  private Tutorial tutorial;
  private StartEMenu startEMenu;

  void Start()
  {
    calculaResultados = GetComponent<ScreenResults>();
    bodyCubo = GetComponent<Rigidbody>();

    tutorial = FindObjectOfType<Tutorial>();
    altar = FindObjectOfType<Teleporter>();
    startEMenu = FindObjectOfType<StartEMenu>();

    bodyCubo.freezeRotation = true;
    isJumper = isEnemy = false;

    startingPosition = bodyCubo.position;
    painelResultados.SetActive(false);
  }

  public void ClickStart(bool b)
  {
    if (bodyCubo.velocity.magnitude == 0 && !isJumper)
    {
      if(!tutorial.isTutorial)
      {
        if(startEMenu.getPrimeiroExercicio())
        {
                    
                    startEMenu.ExibeConfirmacao();
        }
        else
        {
                   GetComponent<AudioSource>().Play();
                    bodyCubo.velocity = calculaResultados.SetUserVelocity();
          isJumper = isEnemy = true;
        }
      }
      else
      {
                GetComponent<AudioSource>().Play();
                bodyCubo.velocity = calculaResultados.SetUserVelocity();
        isJumper = isEnemy = true;
      }
    }
  }

  public void ClickRestore(bool b)
  {
    this.gameObject.SetActive(true);

    bodyCubo.velocity = new Vector3(0, 0, 0);
    bodyCubo.position = startingPosition;

    isJumper = isEnemy = false;
    painelResultados.SetActive(false);
  }

  public void AnimationConfig()
  {
    painelResultados.SetActive(false);
    isJumper = isEnemy = false;
  }
  
  private void OnCollisionEnter(Collision collision)
  {
    if (isJumper)
    {
      bodyCubo.velocity = new Vector3(0, 0, 0);

      calculaResultados.SetOutputParam();
      painelResultados.SetActive(true);
    }
    
    if (isEnemy)
    {
      isEnemy = false; 
      GetComponent<QuestionAnimation>().isQuestionRight();
    }
  }
}
