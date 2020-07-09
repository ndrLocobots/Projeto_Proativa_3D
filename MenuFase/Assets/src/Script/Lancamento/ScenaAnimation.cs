using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ScenaAnimation : MonoBehaviour
{
  public PlayableDirector cameraAnimation, enemyAnimation;

  int showAltarIndex = 3;
  int changeAltarIndex = 4;
  int showCameraIndex = 1;

  bool isPositionChange;

  Tutorial tutorial;
  altarPosition altar;
  Question question;

  void Start()
  {
    tutorial = FindObjectOfType<Tutorial>();
    altar = FindObjectOfType<altarPosition>();
    question = FindObjectOfType<Question>();

    isPositionChange = false;
  }

  public void RestoreAnimation()
  {
    isPositionChange = false;
  }

  public void SetAnimation(int index)
  {
    if (index == showAltarIndex)
    {
      AnimatorCamera();
    }
    else if (index == changeAltarIndex)
    {
      ChangeAltarPosition();
    }
    else if (index == showCameraIndex)
    {
      StartTutorial();
    }
  }

  void AnimatorCamera()
  {
    cameraAnimation.Play();
  }

  void ChangeAltarPosition()
  {
    if (!isPositionChange)
    {
      isPositionChange = true;
      altar.ChangeAltarPosition(question.distaceDelta);
    }
  }

  void StartTutorial()
  {
    tutorial.StartTutorial();
  }

  public float AnimationToLose()
  {
    enemyAnimation.Play();

    return (float)enemyAnimation.duration - 1f;
  }
}
