using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotAnimation : MonoBehaviour
{
  Animator robotAnimator;
  int jumpHash = Animator.StringToHash("isJumping");
  int searchHash = Animator.StringToHash("isSearch");
  float time = 0, fatorBreach = 1, breach;
  bool isTalk = false;
  int keyAnimation;
  const int waitTime = 5;
  void Start()
  {
    robotAnimator = GetComponent<Animator>();
    robotAnimator.SetBool("isStop", true);
  }
  void Update()
  {
    time += Time.deltaTime;
    breach += (Time.deltaTime)/waitTime * fatorBreach;

    robotAnimator.SetFloat("breach", breach);
    isTalk = robotAnimator.GetBool("isTalk");

    if (time > waitTime)
    {
      time = 0;
      fatorBreach = -fatorBreach;

      if (!isTalk)
      {
        keyAnimation = Random.Range(1, 11);
        this.choseAnimation(keyAnimation);
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


