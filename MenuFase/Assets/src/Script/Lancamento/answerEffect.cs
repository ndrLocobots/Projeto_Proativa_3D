using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answerEffect : MonoBehaviour
{
  public string[] setencas;

  public GameObject robotDialog;
  public GameObject altar;
  public GameObject inimigo;
  public GameObject cam;

  public int showCameraIndex = 3;
  public int changeAltarIndex = 4;
  int index = 0;


  void Start()
  {
    setSetences();
    robotDialog.GetComponent<dialog>().setences = setencas;
  }


  void setSetences()
  {
    setencas = new string[6];

    setencas[0] = "Olá explorador, seja bem vindo ao simulador de universos da Locobots. Esse é o seu primeiro desafio";
    setencas[1] = "Graças as atualizações em nossos sistema, esse mundo não possui atrito no ar, e sua gravidade e de 10 m/s², um otimo mundo para se viver =D, veja como e verde nossas florestas !!!";
    setencas[2] = "Acoplado em você há um propussor de última geração. Você pode setar a velocidade e o ângulo que você desejar em seu painel de controle, não utrapassando nossos limites estipulados. Não queremos que você caia no limbo =D.";
    setencas[3] = "Seu objetivo é configurar o propussor para te levar até o nosso teletrasportador";
    setencas[4] = "De acordo com meu relatório, o centro do teletrasportador estar a uma distancia de ";
    setencas[5] = "mas cuidade, atrás dessas árvores há um inimigo a sua espera";
  }

  public void BackSentence()
  {
    index = robotDialog.GetComponent<dialog>().BackSentence();
  }

  public void NextSentence()
  {
    index = robotDialog.GetComponent<dialog>().NextSentence();

    if (index == showCameraIndex + 1)
    {
      AnimatorCamera();
    }
    else if (index == changeAltarIndex + 1)
    {
      ChangeAltarPosition();
    }
  }

  void AnimatorCamera()
  {
    cam.GetComponent<cameraControl>().AnimatorCamera();
  }

  void ChangeAltarPosition()
  {
    altar.GetComponent<altarPosition>().ChangeAltarPosition();

    float distanceToAltar;
    Vector3 delta;

    delta = altar.transform.position - transform.position;
    distanceToAltar = delta.magnitude;

    setencas[4] = setencas[4] + distanceToAltar.ToString("0.00") + " metros de você.";
  }

  public void ActiveEnemy()
  {
    Vector3 deltaDistance = altar.transform.position - transform.position;

    if (deltaDistance.magnitude > 10)
    {

      enemy[] inimigos = inimigo.GetComponentsInChildren<enemy>();
      foreach (enemy inimigo in inimigos)
      {
        inimigo.activeEnemy();
      }

    }
  }
}
