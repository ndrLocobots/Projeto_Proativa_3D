using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class QuestionAnimation : MonoBehaviour
{
  private Transform altar;
  private bool isQuestion;

  private Tutorial tutorial;
  private ScenaAnimation lancamentoAnimation;

  private GenericAnimations ScenaAnimation;

  private heart hearts;
  private dialog robotDialog;

  private Teleporter tele;

  private int attemptsNum = 3;

  private int index;
  private int showAltarIndex = 5;
  private int changeAltarIndex = 6;
  private int showCameraIndex = 1;
  private int questionIndex = 8;
  private int levelIndex = 0;

  private ControleQuestoes controle;

  public GameObject cam;
  public GameObject cube;

  void Start()
  {
    tutorial = FindObjectOfType<Tutorial>();
    lancamentoAnimation = FindObjectOfType<ScenaAnimation>();
    ScenaAnimation = FindObjectOfType<GenericAnimations>();
    controle = FindObjectOfType<ControleQuestoes>();
    robotDialog = FindObjectOfType<dialog>();
    hearts = FindObjectOfType<heart>();
    tele = FindObjectOfType<Teleporter>();

    controle.AtualizaQuestaoAtiva(levelIndex);

    altar = tele.gameObject.transform;

    isQuestion = false;
  }

  public void BackSentence()
  {
    if (!tutorial.isTutorial)
    {
      robotDialog.BackSentence();
    }
  }

  public void NextSentence()
  {
    if (!tutorial.isTutorial)
    {
      index = robotDialog.NextSentence();
      SetAnimation(index);
    }
  }

  public void SetAnimation(int index)
  {
    if (index == showAltarIndex)
    {
      StartCoroutine(ActiveCameraAnimation());
    }
    else if (index == changeAltarIndex)
    {
      lancamentoAnimation.ChangeTeleporterPosition();
    }
    else if (index == showCameraIndex)
    {
      lancamentoAnimation.StartTutorial();
    }
    else if (index == questionIndex && !isQuestion)
    {
      hearts.updateOpacityHearts(1);
      isQuestion = true;
    }
  }

  IEnumerator ActiveCameraAnimation()
  {
    cube.GetComponent<CuboLan>().AnimationConfig();

    yield return new WaitForSeconds(lancamentoAnimation.AnimatorCamera()+0.3f);

    position camera = cam.GetComponent<position>();
    camera.SliderAux(camera.getSliderOption());
  }

  public void isQuestionRight()
  {
    if (isQuestion && !tutorial.isTutorial)
    {

      Vector3 distaceDelta = altar.position - transform.position;

      if (distaceDelta.magnitude < 5)
      {
        CorrectAnswer();
      }
      else
      {
        WrongAnswer();
      }
    }
  }

  void CorrectAnswer()
  {
    lancamentoAnimation.HideEnemy();
    StartCoroutine(ScenaAnimation.ShowReactionOfRobot(true));
    StartCoroutine(ActiveWinAnimation());
    controle.AtualizaQuestaoAtiva(levelIndex + 1);
    controle.setConcluidas(1, levelIndex);

    if(levelIndex <= 3)
      levelIndex++;
    
    tele.setAtingido(true);
  }

  void WrongAnswer()
  {
    lancamentoAnimation.ActiveEnemy();
    StartCoroutine(ScenaAnimation.ShowReactionOfRobot(false));
    robotDialog.SetSadBubble();
    ReduceAttemptsNumber();
  }

  void ReduceAttemptsNumber()
  {
    attemptsNum--;
    hearts.loseHeart();

    if (attemptsNum == 0)
    {
      StartCoroutine(ActiveLoseAnimation());
    }
  }

  IEnumerator ActiveLoseAnimation()
  {
    cube.GetComponent<CuboLan>().AnimationConfig();
    yield return new WaitForSeconds(ScenaAnimation.AnimationToLose());
    lancamentoAnimation.HideEnemy();

    RestoreCena();
    robotDialog.ActivateBubbleSignal();
  }

  IEnumerator ActiveWinAnimation()
  {
    cube.GetComponent<CuboLan>().AnimationConfig();

    yield return new WaitForSeconds(ScenaAnimation.AnimationToWin());

    RestoreCena();

    robotDialog.ActivateBubbleOtherQuestion();
    lancamentoAnimation.ChangeQuestion();
  }

  void RestoreCena()
  {
    attemptsNum = 3;
    isQuestion = false;

    position camera = cam.GetComponent<position>();
    camera.SliderAux(camera.getSliderOption());

    cube.GetComponent<CuboLan>().ClickRestore(true);
    hearts.updateOpacityHearts(0);
  }
}
