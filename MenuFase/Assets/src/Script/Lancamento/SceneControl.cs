using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class SceneControl : MonoBehaviour
{
  public GameObject robotDialog;
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

  void Start()
  {
    tutorial = FindObjectOfType<Tutorial>();
    question = FindObjectOfType<Question>();
    scenaAnimation = FindObjectOfType<ScenaAnimation>();
    robot = FindObjectOfType<robotAnimation>();

    robotDialog.GetComponent<dialog>().setences = question.GetSetences();

    isQuestion = false;
  }

  public void BackSentence()
  {
    if (!tutorial.isTutorial)
    {
      robotDialog.GetComponent<dialog>().BackSentence();
    }
  }

  public void NextSentence()
  {
    if (!tutorial.isTutorial)
    {
      int index = robotDialog.GetComponent<dialog>().NextSentence();
      scenaAnimation.SetAnimation(index);

      isQuestion = true;
    }
  }

  public void ActiveEnemy()
  {
    Vector3 distaceDelta = altar.transform.position - transform.position;

    if (isQuestion &&  !tutorial.isTutorial)
    {
      if (distaceDelta.magnitude > 10)
      {

        enemy[] inimigos = inimigo.GetComponentsInChildren<enemy>();
        foreach (enemy inimigo in inimigos)
        {
          inimigo.activeEnemy();
        }

        StartCoroutine(UpdateTryNumber());
        StartCoroutine(ShowReactionOfRobot(false));
      }
      else
      {
        StartCoroutine(ShowReactionOfRobot(true));
      }
    }
  }

  IEnumerator UpdateTryNumber()
  {
    tryNumber--;

    if (tryNumber == 0)
    {
      yield return new WaitForSeconds(scenaAnimation.AnimationToLose());
      ActiveEnemy();
      ReestoreCena();
    }
  }

  void ReestoreCena()
  {
    tryNumber = 3;
    isQuestion = false;

    cam.GetComponent<position>().SliderAux(1);
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
