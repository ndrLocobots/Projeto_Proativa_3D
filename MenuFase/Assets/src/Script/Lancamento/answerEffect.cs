using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
public class answerEffect : MonoBehaviour
{
  public string[] setencas;

  public GameObject robotDialog;
  public GameObject altar;
  public GameObject inimigo;
  public GameObject cam;

  public GameObject cube;

  public PlayableDirector enemyAnimation, cameraAnimation;

  public RectTransform arrow, menuComponent, angleComponent, velocityComponent;

  int showAltarIndex = 3;
  int changeAltarIndex = 4;
  int showCameraIndex = 1;
  int index = 0;

  bool isQuestion, changedPosition;
  int numberOfAttempts = 3;

  float distaceDelta, velocityX, velocityY, time, maxHeight;

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
    maxHeight = velocityY * time / 2;

    Debug.Log("Angulo " + angle + " Velocidade " + velocity);
  }

  void setSetences()
  {
    setencas = new string[7];

    setencas[0] = "Olá gamer, meu nome é locobits !! Estou muito feliz de ter você aqui comigo. Seja bem vindo ao simulador de universos da Locobots.";

    setencas[1] = "Você escolheu a simulação de lançamento vertical. Graças às atualizações em  nossos sistema, esse mundo não possui atrito no ar, e sua gravidade é de 10 m/s², um ótimo mundo  para se fazer experimento, Dê uma explorada em nossa linda paisagem ";

    setencas[2] = "(Colocar teoria do lançamento vertical, curiosidades)";

    setencas[3] = "Agora que você já aprendeu como funciona o lançamento vertical, vamos testar o seu conhecimento!\n \nSeu objetivo nessa fase é chegar até o nosso teletransportador, para isso configure seu propussor no seu painel de controle.";

    setencas[4] = "Ops, parece que seu teletransportador mudou de posição";

    setencas[5] = returnQuestion();

    setencas[6] = "Cuidado! Se você errar, atrás dessas árvores há inimigos à sua espera.";
  }

  string returnQuestion()
  {
    string[] question = new string[2];

    int index = Random.Range(0, 2);

    question[0] = "De acordo com meu relatório, o centro do teletransportador está a uma distância e tempo de " + distaceDelta.ToString("0.00") + " metros e " + time.ToString("0.00") + " segundos de você";

    question[1] = "De acordo com meu relatório, você atingirá a altura máxima, " + maxHeight.ToString("0.00") + "metros, em " + (time/2).ToString("0.00") + " segudos.";

    return question[index];
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
    if (index == showAltarIndex)
    {
      AnimatorCamera();
    }
    else if (index == changeAltarIndex)
    {
      ChangeAltarPosition();
    }
    else if (index == showCameraIndex)
    {
      ShowHowUsePainel();
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

  void ShowHowUsePainel()
  {
    arrow.position = new Vector3 ( menuComponent.position.x, menuComponent.position.y,menuComponent.position.z);
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

    yield return new WaitForSeconds((float)enemyAnimation.duration - 1f);

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
