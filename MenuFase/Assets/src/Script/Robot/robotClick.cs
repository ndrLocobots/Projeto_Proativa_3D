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

  public GameObject timer;
  public Button botaoStart;
  public Button botaoMenu;

  void Awake()
  {
    hearts = FindObjectOfType<heart>();
    controleBotoes = FindObjectOfType<ControleBotoes>();
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

        if(SceneManager.GetActiveScene().name == "Plano")
        {
          ParticularidadesPlano();
        }
      }
    }
  }

  void ParticularidadesPlano()
  {
    QuestionPlano questionPlano = FindObjectOfType<QuestionPlano>();
    controleBotoes.HabilitaBotoes();

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

  void OnMouseEnter()
  {
    mouseOnCollider = true;
  }

  void OnMouseExit()
  {
    mouseOnCollider = false;
  }
}
