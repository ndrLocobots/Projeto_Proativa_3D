using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class GenericAnimations : MonoBehaviour
{
  public PlayableDirector winAnimation, loseAnimation, wrongAnimation;
  public GameObject robotSelfCam, buttons;
  private robotAnimation robot;

  void Start()
  {
    robot = FindObjectOfType<robotAnimation>();
  }

  public void AnimatorCamera()
  {
    winAnimation.Play();
  }

  public float AnimationToWrongAnswer()
  {
    wrongAnimation.Play();

    return (float)wrongAnimation.duration - 0.1f;
  }

  public float AnimationToLose()
  {
    loseAnimation.Play();

    return (float)loseAnimation.duration - 1f;
  }

  public float AnimationToWin()
  {
    winAnimation.Play();

    return (float)winAnimation.duration + 0.5f;
  }

  public IEnumerator ShowReactionOfRobot(bool reaction)
  {
    robotSelfCam.SetActive(true);
    if(buttons)
      buttons.SetActive(false);

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
    if(buttons)
      buttons.SetActive(true);
  }
}
