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

  public bool isJumper;

  void Start()
  {
    script = GetComponent<ScreenResults>();

    body = GetComponent<Rigidbody>();
    body.freezeRotation = true;

    isJumper = false;

    startingPosition = body.position;
    panel.SetActive(false);
  }

  public void ClickStart(bool b)
  {
    if (body.velocity.magnitude == 0)
    {
      body.velocity = script.SetUserVelocity();
      isJumper = true;
    }
  }

  public void ClickRestore(bool b)
  {
    body.velocity = new Vector3(0, 0, 0);
    body.position = startingPosition;
    isJumper = false;
    panel.SetActive(false);
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (isJumper)
    {
      body.velocity = new Vector3(0, 0, 0);
      script.SetOutputParam();
      panel.SetActive(true);
    }
  }
}
