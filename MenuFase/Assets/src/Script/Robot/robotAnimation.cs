using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotAnimation : MonoBehaviour
{
  [SerializeField]
  Animator robotAnimator;

  int jumpHash = Animator.StringToHash("jumping");
  int searchHash = Animator.StringToHash("search");
  int lookHash = Animator.StringToHash("look");
  int fingerHash = Animator.StringToHash("finger");
  int waveHash = Animator.StringToHash("wave");
  int sadHash = Animator.StringToHash("sad");
  int happyHash = Animator.StringToHash("happy");


  float time = 0, changeSenseBreach = 1, breach;
  const int waitTime = 5;

  void Start()
  {
    robotAnimator = GetComponent<Animator>();
    robotAnimator.SetBool("isStop", true);
  }

  void Update()
  {
    time += Time.deltaTime;
    breach += (Time.deltaTime) / waitTime * changeSenseBreach;

    robotAnimator.SetFloat("breach", breach);

    if (time > waitTime)
    {
      time = 0;
      changeSenseBreach = -changeSenseBreach;
      this.choseAnimation();
    }
  }

  void choseAnimation()
  {
    int key = Random.Range(1, 13);

    if (key == 1)
    {
      robotAnimator.SetTrigger(lookHash);
    }
    else if (key <= 3)
    {
      robotAnimator.SetTrigger(searchHash);
    }
    else if (key <= 6)
    {
      robotAnimator.SetTrigger(jumpHash);
    }
    else if (key <= 8)
    {
      robotAnimator.SetTrigger(fingerHash);
    }
    else if (key <= 12)
    {
      robotAnimator.SetTrigger(waveHash);
    }
  }

  public void RobotSad()
  {
    robotAnimator.SetTrigger(sadHash);
  }

  public void RobotHappy()
  {
    robotAnimator.SetTrigger(happyHash);
  }

  public void RobotTalk(bool isTalk)
  {
    robotAnimator.SetBool("isTalk", isTalk);
  }
}


