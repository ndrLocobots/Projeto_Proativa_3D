using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class SceneControl : MonoBehaviour
{
  public GameObject altar;
  public GameObject inimigo;
  public GameObject cam, camSelfRobot;
  public GameObject cube;

  bool isQuestion;
  int tryNumber = 3;

  Tutorial tutorial;
  Question question;
  robotAnimation robot;
  ScenaAnimation scenaAnimation;

  dialog robotDialog;

  void Start()
  {
    tutorial = FindObjectOfType<Tutorial>();
    question = FindObjectOfType<Question>();
    scenaAnimation = FindObjectOfType<ScenaAnimation>();
    robot = FindObjectOfType<robotAnimation>();
    robotDialog = FindObjectOfType<dialog>();

    robotDialog.setences = question.GetSetences();
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
      scenaAnimation.SetAnimation(index);

      isQuestion = true;
    }
  }

  public void isQuestionRight()
  {
    if (isQuestion && !tutorial.isTutorial)
    {

      Vector3 distaceDelta = altar.transform.position - transform.position;

      if (distaceDelta.magnitude > 10)
      {
        ActiveEnemy();
        StartCoroutine(UpdateTryNumber());
        StartCoroutine(ShowReactionOfRobot(false));
        robotDialog.SetSadBubble();
      }
      else
      {
        StartCoroutine(ShowReactionOfRobot(true));
        robotDialog.SetHappyBubble();
      }
    }
  }

  void ActiveEnemy()
  {
    enemy[] inimigos = inimigo.GetComponentsInChildren<enemy>();
    foreach (enemy inimigo in inimigos)
    {
      inimigo.activeEnemy();
    }
  }

  IEnumerator UpdateTryNumber()
  {
    tryNumber--;

    if (tryNumber == 0)
    {
      cube.GetComponent<CuboLan>().LoseConfig();
      yield return new WaitForSeconds(scenaAnimation.AnimationToLose());
      ActiveEnemy();
      robotDialog.ActivateBubbleSignal();
      ReestoreCena();
    }
  }

  void ReestoreCena()
  {
    tryNumber = 3;
    isQuestion = false;

    cam.GetComponent<position>().SliderAux(0);
    cube.GetComponent<CuboLan>().ClickRestore(true);
    scenaAnimation.RestoreAnimation();

    Debug.Log("You lose");
  }

  IEnumerator ShowReactionOfRobot(bool reaction)
  {
    camSelfRobot.SetActive(true);

    if (reaction)
    {
      robot.RobotHappy();
    }
    else
    {
      robot.RobotSad();
    }

    yield return new WaitForSeconds(5);
    camSelfRobot.SetActive(false);
  }
}
