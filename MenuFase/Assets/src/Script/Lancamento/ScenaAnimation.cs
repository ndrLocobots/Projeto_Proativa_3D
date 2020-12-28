using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class ScenaAnimation : MonoBehaviour
{
  public PlayableDirector cameraAnimation, enemyAnimation;
  public GameObject robotSelfCam;
  public GameObject inimigo;

  private Tutorial tutorial;
  private Question question;
  private robotAnimation robot;
  private Teleporter teleporter;

  public GameObject respostas;
  void Start()
  {
    question = gameObject.AddComponent<Question>();
    tutorial = FindObjectOfType<Tutorial>();
    teleporter = FindObjectOfType<Teleporter>();
    robot = FindObjectOfType<robotAnimation>();
  }

  void FixedUpdate()
  {
    if (Input.GetKeyDown(KeyCode.H))
    {
      respostas.GetComponent<Text>().text = question.ReturnAnswer();
      respostas.SetActive(!respostas.activeSelf);
    }
  }

  public void AnimatorCamera()
  {
    cameraAnimation.Play();
  }

  public void ChangeQuestion()
  {
    question.SetRobotDialog();
    ChangeTeleporterPosition();
  }

  public void ChangeTeleporterPosition()
  {
    teleporter.ChangeTeleporterPosition(question.distaceDelta);
    teleporter.ativaIdle();
  }

  public void StartTutorial()
  {
    tutorial.StartTutorial();
  }

  public void ActiveEnemy()
  {
    enemy[] inimigos = inimigo.GetComponentsInChildren<enemy>();
    foreach (enemy inimigo in inimigos)
    {
      inimigo.activeEnemy();
    }
  }

  public void HideEnemy()
  {
    enemy[] inimigos = inimigo.GetComponentsInChildren<enemy>();
    foreach (enemy inimigo in inimigos)
    {
      inimigo.HideEnemy();
    }
  }

  public float AnimationToLose()
  {
    enemyAnimation.Play();

    return (float)enemyAnimation.duration - 1f;
  }

  public float AnimationToWin()
  {
    cameraAnimation.Play();

    return (float)cameraAnimation.duration + 0.5f;
  }

  public IEnumerator ShowReactionOfRobot(bool reaction)
  {
    robotSelfCam.SetActive(true);

    if (reaction)
    {
      robot.RobotHappy();
    }
    else
    {
      robot.RobotSad();
    }

    yield return new WaitForSeconds(5);
    robotSelfCam.SetActive(false);
  }
}
