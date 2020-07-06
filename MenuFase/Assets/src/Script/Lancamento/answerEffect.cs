using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class answerEffect : MonoBehaviour
{
  public string[] setencas;

  public GameObject robotDialog;
  public GameObject altar;
  public GameObject inimigo;
  public GameObject cam;

  public GameObject cube;

  public PlayableDirector enemyAnimation, cameraAnimation;
  int showCameraIndex = 3;
  int changeAltarIndex = 4;
  int index = 0;

  bool isQuestion, changedPosition;
  int numberOfAttempts = 3;

  float distaceDelta, velocityX, velocityY, time;

  void Start()
  {
    MakeDataQuestion();
    setSetences();
    robotDialog.GetComponent<dialog>().setences = setencas;
    isQuestion = false;
    changedPosition = false;
  }

  void MakeDataQuestion()
  {
    float velocity = Random.Range(10.0f, 50f);
    float angle = Random.Range(1, 80f);

    angle = angle * Mathf.PI / 180;
    velocityY = velocity * Mathf.Sin(angle);
    velocityX = velocity * Mathf.Cos(angle);

    time = velocityY / 5;
    distaceDelta = velocityX * time;

    Debug.Log("Angulo " + angle + " Velocidade " + velocity);
  }

  void setSetences()
  {
    setencas = new string[7];

    setencas[0] = "Olá explorador, seja bem vindo ao simulador de universos da Locobots. Esse é o seu primeiro desafio";
    setencas[1] = "Graças as atualizações em nossos sistema, esse mundo não possui atrito no ar, e sua gravidade é de 10 m/s², um otimo mundo para se viver, Dê uma olhada em nossa linda paisagem !!!";
    setencas[2] = "Acoplado em você há um propussor de última geração. Você pode setar a velocidade e o ângulo que você desejar em seu painel de controle, não utrapassando nossos limites estipulados. Não queremos que você caia no limbo =D.";
    setencas[3] = "Seu objetivo é configurar o propussor para te levar até o nosso teletrasportador";
    setencas[4] = "Ops, parece que seu teletransportador mudou de posição";
    setencas[5] = "De acordo com meu relatório, o centro do teletrasportador está a uma distância de "
    + distaceDelta.ToString("0.00") + " metros de você. O tempo necessário que você conseguirá é de " + time.ToString("0.00") + " segundos";
    setencas[6] = "Mas cuidade, atrás dessas árvores há um inimigo a sua espera";
  }

  public void BackSentence()
  {
    index = robotDialog.GetComponent<dialog>().BackSentence();
  }

  public void NextSentence()
  {
    index = robotDialog.GetComponent<dialog>().NextSentence();
    SetAnimation(index);
    isQuestion = true;
  }

  void SetAnimation(int index)
  {
    if (index == showCameraIndex)
    {
      AnimatorCamera();
    }
    else if (index == changeAltarIndex)
    {
      ChangeAltarPosition();
    }
  }

  void AnimatorCamera()
  {
    cameraAnimation.Play();
  }

  void ChangeAltarPosition()
  {
    if (!changedPosition)
    {
      changedPosition = true;
      altar.GetComponent<altarPosition>().ChangeAltarPosition(distaceDelta);
    }
  }

  public void ActiveEnemy()
  {
    Vector3 distaceDelta = altar.transform.position - transform.position;

    if (distaceDelta.magnitude > 10 && isQuestion)
    {

      enemy[] inimigos = inimigo.GetComponentsInChildren<enemy>();
      foreach (enemy inimigo in inimigos)
      {
        inimigo.activeEnemy();
      }

      UpdateAttempts();
    }
  }

  void UpdateAttempts()
  {
    numberOfAttempts--;

    if (numberOfAttempts == 0)
    {
      StartCoroutine(AnimationToLose());
    }
  }

  IEnumerator AnimationToLose()
  {
    cam.GetComponent<position>().SliderAux(0);
    enemyAnimation.Play();

    yield return new WaitForSeconds((float) enemyAnimation.duration - 1f);

    ActiveEnemy();
    ReestoreCena();
  }

  void ReestoreCena()
  {
    numberOfAttempts = 3;
    isQuestion = false;
    changedPosition = false;

    cam.GetComponent<position>().SliderAux(1);
    cube.GetComponent<CuboLan>().ClickRestore(true);
    Debug.Log("You lose");
  }

}
