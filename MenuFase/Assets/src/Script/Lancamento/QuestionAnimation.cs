using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class QuestionAnimation : MonoBehaviour
{
  public Transform altar;

  public GameObject cam;
  public GameObject cube;

  bool isQuestion;
  int tryNumber = 3;

  Tutorial tutorial;
  ScenaAnimation scenaAnimation;
  heart hearts;

  dialog robotDialog;

  int showAltarIndex = 3;
  int changeAltarIndex = 4;
  int showCameraIndex = 1;
  int questionIndex = 6;

  void Start()
  {
    tutorial = FindObjectOfType<Tutorial>();
    scenaAnimation = FindObjectOfType<ScenaAnimation>();
    robotDialog = FindObjectOfType<dialog>();
    hearts = FindObjectOfType<heart>();

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
      int index = robotDialog.NextSentence();
      SetAnimation(index);

      isQuestion = true;
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
      scenaAnimation.ChangeAltarPosition();
    }
    else if (index == showCameraIndex)
    {
      scenaAnimation.StartTutorial();
    }
    else if (index == questionIndex)
    {
      hearts.updateOpacityHearts(1);
    }
  }

  public void isQuestionRight()
  {
    if (isQuestion && !tutorial.isTutorial)
    {

      Vector3 distaceDelta = altar.position - transform.position;

      if (distaceDelta.magnitude < 10)
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
    StartCoroutine(ActiveAnimationToWin());
  }

  void WrongAnswer()
  {
    scenaAnimation.ActiveEnemy();
    StartCoroutine(scenaAnimation.ShowReactionOfRobot(false));
    robotDialog.SetSadBubble();
    UpdateTryNumber();
  }

  void UpdateTryNumber()
  {
    tryNumber--;
    hearts.loseHeart();

    if (tryNumber == 0)
    {
      StartCoroutine(ActiveAnimationToLose());
    }
  }

  IEnumerator ActiveAnimationToLose()
  {
    cube.GetComponent<CuboLan>().AnimationConfig();
    yield return new WaitForSeconds(scenaAnimation.AnimationToLose());
    scenaAnimation.HideEnemy();

    cam.GetComponent<position>().SliderAux(0);
    ReestoreCena();
    robotDialog.ActivateBubbleSignal();
  }

  IEnumerator ActiveAnimationToWin()
  {
    cube.GetComponent<CuboLan>().AnimationConfig();

    yield return new WaitForSeconds(scenaAnimation.AnimationToWin());
    cam.GetComponent<position>().SliderAux(0);

    ReestoreCena();

    robotDialog.ActivateBubbleOtherQuestion();
    scenaAnimation.ChangeQuestion();
  }

  void ReestoreCena()
  {
    tryNumber = 3;
    isQuestion = false;

    cube.GetComponent<CuboLan>().ClickRestore(true);
    hearts.updateOpacityHearts(0);
  }

}
