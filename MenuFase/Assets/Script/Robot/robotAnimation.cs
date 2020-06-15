using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotAnimation : MonoBehaviour
{
  public Animator robotAnimator;
  int jumpHash = Animator.StringToHash("isJumping");
  int searchHash = Animator.StringToHash("isSearch");
  public bool isTalk = false;
  float time = 0, changeSenseBreach = 1, breach;
  int randomKeyAnimation;
  const int waitTime = 5;
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
        randomKeyAnimation = Random.Range(1, 11);
        this.choseAnimation(randomKeyAnimation);
      }
    }
  }
  void choseAnimation(int key)
  {
    if (key == 1)
    {
      robotAnimator.SetTrigger(jumpHash);
    }
    else if (key <= 3)
    {
      robotAnimator.SetTrigger(searchHash);
    }
    else if (key <= 5)
    {
      robotAnimator.SetBool("isLook", true);
    }
    else if (key <= 10)
    {
      robotAnimator.SetBool("isLook", false);
    }
  }

}


