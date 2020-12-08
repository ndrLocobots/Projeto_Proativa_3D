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
  private ScenaAnimation scenaAnimation;
  private heart hearts;
  private dialog robotDialog;

  private Teleporter tele;

  private int attemptsNum = 3;

  private int index;
  private int showAltarIndex = 5;
  private int changeAltarIndex = 6;
  private int showCameraIndex = 1;
  private int questionIndex = 8;

  public GameObject cam;
  public GameObject cube;

  void Start()
  {
    tutorial = FindObjectOfType<Tutorial>();
    scenaAnimation = FindObjectOfType<ScenaAnimation>();
    robotDialog = FindObjectOfType<dialog>();
    hearts = FindObjectOfType<heart>();
    tele = FindObjectOfType<Teleporter>();

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
      scenaAnimation.AnimatorCamera();
    }
    else if (index == changeAltarIndex)
    {
      scenaAnimation.ChangeTeleporterPosition();
    }
    else if (index == showCameraIndex)
    {
      scenaAnimation.StartTutorial();
    }
    else if (index == questionIndex && !isQuestion)
    {
      hearts.updateOpacityHearts(1);
      isQuestion = true;
    }
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
    scenaAnimation.HideEnemy();
    StartCoroutine(scenaAnimation.ShowReactionOfRobot(true));
    StartCoroutine(ActiveWinAnimation());
    tele.setAtingido(true);
  }

  void WrongAnswer()
  {
    scenaAnimation.ActiveEnemy();
    StartCoroutine(scenaAnimation.ShowReactionOfRobot(false));
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
    yield return new WaitForSeconds(scenaAnimation.AnimationToLose());
    scenaAnimation.HideEnemy();

    position camera = cam.GetComponent<position>();
    camera.SliderAux(camera.getSliderOption());

    RestoreCena();
    robotDialog.ActivateBubbleSignal();
  }

  IEnumerator ActiveWinAnimation()
  {
    cube.GetComponent<CuboLan>().AnimationConfig();

    yield return new WaitForSeconds(scenaAnimation.AnimationToWin());

    position camera = cam.GetComponent<position>();
    camera.SliderAux(camera.getSliderOption());

    RestoreCena();

    robotDialog.ActivateBubbleOtherQuestion();
    scenaAnimation.ChangeQuestion();
  }

  void RestoreCena()
  {
    attemptsNum = 3;
    isQuestion = false;

    cube.GetComponent<CuboLan>().ClickRestore(true);
    hearts.updateOpacityHearts(0);
  }

  public void setIndex(int value)
  {
    this.index = value;
  }

  public int getIndex()
  {
    return this.index;
  }
}
