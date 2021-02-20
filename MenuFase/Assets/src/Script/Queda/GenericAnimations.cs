using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class GenericAnimations : MonoBehaviour
{
  public PlayableDirector cameraAnimation, enemyAnimation;
  public GameObject robotSelfCam;

  private robotAnimation robot;

  void Start()
  {
    robot = FindObjectOfType<robotAnimation>();
  }

  public void AnimatorCamera()
  {
    cameraAnimation.Play();
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
