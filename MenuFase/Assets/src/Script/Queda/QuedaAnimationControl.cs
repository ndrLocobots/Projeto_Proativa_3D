using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class QuedaAnimationControl : MonoBehaviour
{
  private bool isQuestion;

  [SerializeField]
  private GenericAnimations cenaAnimation;

  [SerializeField]
  private heart hearts;

  [SerializeField]
  private dialog robotDialog;

  [SerializeField]
  private QuestionQueda question;

  [SerializeField]
  private enemy inimigo;

  private int attemptsNum = 3;

  private int index;
  private int showInimigo = 5;
  private int questionIndex = 8;

  public GameObject secondCamera;
  public GameObject cube;

  void Start()
  {
    cenaAnimation = FindObjectOfType<GenericAnimations>();
    robotDialog = FindObjectOfType<dialog>();
    hearts = FindObjectOfType<heart>();
    question = FindObjectOfType<QuestionQueda>();
    inimigo = FindObjectOfType<enemy>();
    isQuestion = false;
  }

  public void BackSentence()
  {
    robotDialog.BackSentence();
  }

  public void NextSentence()
  {
    index = robotDialog.NextSentence();
    SetAnimation(index);

  }

  public void SetAnimation(int index)
  {
    if (index == showInimigo)
    {
      //cenaAnimation.AnimatorCamera();
    }
    else if (index == questionIndex && !isQuestion)
    {
      hearts.updateOpacityHearts(1);
      isQuestion = true;
    }
  }

  public void isQuestionRight(float userAnswer)
  {
    if (isQuestion)
    {
      float answer = question.ReturnAnswer();

      if (userAnswer == answer)
      {
        CorrectAnswer();
        question.SetRobotDialog();
      }
      else
      {
        WrongAnswer(userAnswer);
      }
    }
  }

  void CorrectAnswer()
  {
    StartCoroutine(cenaAnimation.ShowReactionOfRobot(true));
    StartCoroutine(ActiveWinAnimation());
  }

  IEnumerator ActiveWinAnimation()
  {
    secondCamera.SetActive(true);
    Vector3 position = cube.transform.position;
    position.y = 0.98f;

    inimigo.SetVelocity(0, 0);
    inimigo.SetPosition(position);

    float time = question.ReturnAnswer();

    yield return new WaitForSeconds(time + 3);

    RestoreCena();
    robotDialog.ActivateBubbleOtherQuestion();
  }

  void WrongAnswer(float time)
  {
    StartCoroutine(cenaAnimation.ShowReactionOfRobot(false));
    robotDialog.SetSadBubble();
    ReduceAttemptsNumber(time);
  }

  void ReduceAttemptsNumber(float time)
  {
    attemptsNum--;
    hearts.loseHeart();

    if (attemptsNum == 0)
    {
      StartCoroutine(ActiveLoseAnimation());
    }
    else
    {
      StartCoroutine(ActiveWrongAnimation(time));
    }
  }

  IEnumerator ActiveLoseAnimation()
  {
    //yield return new WaitForSeconds(cenaAnimation.AnimationToLose());
    //cenaAnimation.HideEnemy();
    yield return new WaitForSeconds(3);

    RestoreCena();
    robotDialog.ActivateBubbleSignal();
  }

  IEnumerator ActiveWrongAnimation(float time)
  {
    secondCamera.SetActive(true);

    inimigo.SetVelocity(time, cube.transform.position.z - 2f);
    yield return new WaitForSeconds(time + 3);

    inimigo.RestorePosition();
    inimigo.SetVelocity(0, 0);

    secondCamera.SetActive(false);
  }

  void RestoreCena()
  {
    attemptsNum = 3;
    isQuestion = false;
    secondCamera.SetActive(false);

    cube.GetComponent<Control>().RestartButton();
    hearts.updateOpacityHearts(0);
    inimigo.RestorePosition();
  }

}
