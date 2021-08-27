using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class robotClick : MonoBehaviour
{
  bool mouseOnCollider = false;

  private heart hearts;
  private ControleBotoes controleBotoes;
  private ControleAnimacoes controleAnimacoes;
  private QuedaAnimationControl quedaAnimationControl;

  public GameObject timer;
  public Button botaoStart;
  public Button botaoMenu;
  public Button botaoRestore;

  void Awake()
  {
    hearts = FindObjectOfType<heart>();
    controleBotoes = FindObjectOfType<ControleBotoes>();

    if(SceneManager.GetActiveScene().name == "Plano")
      controleAnimacoes = FindObjectOfType<ControleAnimacoes>();
    else if(SceneManager.GetActiveScene().name == "Queda")
      quedaAnimationControl = FindObjectOfType<QuedaAnimationControl>();
  }

  void Update()
  {
    if (mouseOnCollider)
    {
      if (Input.GetMouseButtonDown(0))
      {
        GetComponent<dialog>().Talk();
        botaoStart.interactable = true;
        botaoMenu.interactable = true;
        botaoRestore.interactable = true;

        if(SceneManager.GetActiveScene().name == "Plano")
        {
          ParticularidadesPlano();
        }
        else if(SceneManager.GetActiveScene().name == "Queda")
        {
          ParticularidadesQueda();
        }
      }
    }
  }

  void ParticularidadesPlano()
  {
    QuestionPlano questionPlano = FindObjectOfType<QuestionPlano>();
    controleBotoes.HabilitaBotoes();
    controleAnimacoes.setEstResolvendo(true);
    controleAnimacoes.setTempoInicio();

    hearts.updateOpacityHearts(1);
    timer.GetComponent<Text>().enabled = true;
    
    if(questionPlano.indice == 0)
    {
      if(!questionPlano.sliderAtrito.gameObject.activeSelf)
      {
        questionPlano.sliderAtrito.gameObject.SetActive(true);
        questionPlano.sliderForca.gameObject.SetActive(false);
      }

      questionPlano.sliderMassa.interactable = false;
      questionPlano.textoMassa.color = Color.gray;
    }
    else if(questionPlano.indice == 1)
    {
      if(questionPlano.sliderMassa.interactable == false)
      {
        questionPlano.sliderMassa.interactable = true;
        questionPlano.textoMassa.color = Color.black;
      }
      questionPlano.sliderAtrito.gameObject.SetActive(false);
      questionPlano.sliderForca.gameObject.SetActive(true);
    }
  }

  void ParticularidadesQueda()
  {
    ButtonControl control = FindObjectOfType<ButtonControl>();

    quedaAnimationControl.setEstResolvendo(true);
    quedaAnimationControl.setTempoInicio();

    control.Habilita();
  }

  void OnMouseEnter()
  {
    mouseOnCollider = true;
  }

  void OnMouseExit()
  {
    mouseOnCollider = false;
  }
}
