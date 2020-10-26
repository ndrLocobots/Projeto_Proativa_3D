using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ScenaAnimation : MonoBehaviour
{
  public PlayableDirector cameraAnimation, enemyAnimation;
  private Altar altar;

  Tutorial tutorial;
  Question question;

  robotAnimation robot;
  public GameObject robotSelfCam;

  TeleporterPosition teleporter;
  public GameObject inimigo;


  void Start()
  {
    question = gameObject.AddComponent<Question>();
    tutorial = FindObjectOfType<Tutorial>();
    teleporter = FindObjectOfType<TeleporterPosition>();
    robot = FindObjectOfType<robotAnimation>();
    altar = FindObjectOfType<Altar>();
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
    altar.ativaIdle();
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
