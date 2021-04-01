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

  private int attemptsNum = 3;

  private int index;
  private int showInimigo = 2;

  private int questionIndex = 3;

  public GameObject secondCamera;
  public GameObject cube;

  void Start()
  {
    cenaAnimation = FindObjectOfType<GenericAnimations>();
    robotDialog = FindObjectOfType<dialog>();
    hearts = FindObjectOfType<heart>();
    question = FindObjectOfType<QuestionQueda>();
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
    else if (index >= questionIndex && !isQuestion)
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

    float time = question.ReturnAnswer();

    yield return new WaitForSeconds(time + 3);

    RestoreCena();
    robotDialog.ActivateBubbleOtherQuestion();
  }

  void WrongAnswer(float time)
  {
    attemptsNum--;
    hearts.loseHeart();

    if (attemptsNum == 0)
    {
      StartCoroutine(ActiveLoseAnimation());
    }
    else
    {
      StartCoroutine(cenaAnimation.ShowReactionOfRobot(false));
      robotDialog.SetSadBubble();
      StartCoroutine(ActiveWrongAnimation(time));
    }
  }

  IEnumerator ActiveLoseAnimation()
  {
    RestoreCena();
    yield return new WaitForSeconds(cenaAnimation.AnimationToLose());
    RestoreCena();
    robotDialog.ActivateBubbleSignal();
  }

  IEnumerator ActiveWrongAnimation(float time)
  {
    secondCamera.SetActive(true);
    yield return new WaitForSeconds(cenaAnimation.AnimationToWrongAnswer());
    secondCamera.SetActive(false);
  }

  void RestoreCena()
  {
    attemptsNum = 3;
    isQuestion = false;
    secondCamera.SetActive(false);

    cube.GetComponent<Control>().RestartButton();
    hearts.updateOpacityHearts(0);
  }

}
