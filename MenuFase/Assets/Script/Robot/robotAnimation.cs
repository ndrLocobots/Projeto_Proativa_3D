using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotAnimation : MonoBehaviour
{
  public Animator robotAnimator;
  int jumpHash = Animator.StringToHash("jumping");
  int searchHash = Animator.StringToHash("search");
  int lookHash = Animator.StringToHash("look");
  int fingerHash = Animator.StringToHash("finger");
  int waveHash = Animator.StringToHash("wave");
  public bool isTalk = false;
  float time = 0, changeSenseBreach = 1, breach;
  int randomKeyAnimation;
  const int waitTime = 05;
  void Start()
  {
    robotAnimator = GetComponent<Animator>();
    robotAnimator.SetBool("isStop", true);
  }
  void Update()
  {
    time += Time.deltaTime;
    breach += (Time.deltaTime)/waitTime * changeSenseBreach;

    robotAnimator.SetFloat("breach", breach);
    isTalk = robotAnimator.GetBool("isTalk");

    if (time > waitTime)
    {
      time = 0;
      changeSenseBreach = -changeSenseBreach;

      if (!isTalk)
      {
        randomKeyAnimation = Random.Range(1, 13);
        this.choseAnimation(randomKeyAnimation);
      }
    }
  }
  void choseAnimation(int key)
  {
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

}


