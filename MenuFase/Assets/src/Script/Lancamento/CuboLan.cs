using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CuboLan : MonoBehaviour
{
  Rigidbody body;
  public GameObject panel;
  ScreenResults script;
  Vector3 startingPosition;

  bool isJumper, isEnemy;

  void Start()
  {
    script = GetComponent<ScreenResults>();

    body = GetComponent<Rigidbody>();
    body.freezeRotation = true;

    isJumper = isEnemy = false;

    startingPosition = body.position;
    panel.SetActive(false);
  }

  public void ClickStart(bool b)
  {
    if (body.velocity.magnitude == 0 && !isJumper)
    {
      body.velocity = script.SetUserVelocity();
      isJumper = isEnemy =true;
    }
  }

  public void ClickRestore(bool b)
  {
    body.velocity = new Vector3(0, 0, 0);
    body.position = startingPosition;
    isJumper = isEnemy =false;
    panel.SetActive(false);
  }

  public void LoseConfig(){
    panel.SetActive(false);
    isJumper = isEnemy = false;
  }
  
  private void OnCollisionEnter(Collision collision)
  {
    if (isJumper)
    {
      body.velocity = new Vector3(0, 0, 0);
      script.SetOutputParam();
      panel.SetActive(true);
    }

    if (isEnemy){
      isEnemy = false; 
      GetComponent<SceneControl>().isQuestionRight();
    }

  }

}
