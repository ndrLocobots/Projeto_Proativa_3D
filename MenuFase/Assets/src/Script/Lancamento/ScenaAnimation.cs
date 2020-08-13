using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ScenaAnimation : MonoBehaviour
{
  public PlayableDirector cameraAnimation, enemyAnimation;

  bool isPositionChange;

  Tutorial tutorial;
  Question question;

  robotAnimation robot;
  public GameObject robotSelfCam;

  altarPosition altar;
  public GameObject inimigo;

  void Start()
  {
    tutorial = FindObjectOfType<Tutorial>();
    altar = FindObjectOfType<altarPosition>();
    question = FindObjectOfType<Question>();
    robot = FindObjectOfType<robotAnimation>();

    isPositionChange = false;
  }

  public void AnimatorCamera()
  {
    cameraAnimation.Play();
  }

  public void ChangeAltarPosition()
  {
    if (!isPositionChange)
    {
      isPositionChange = true;
      altar.ChangeAltarPosition(question.distaceDelta);
    }
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

  public void HideEnemy(){
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
    enemyAnimation.Play();

    return (float)enemyAnimation.duration - 1f;
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
