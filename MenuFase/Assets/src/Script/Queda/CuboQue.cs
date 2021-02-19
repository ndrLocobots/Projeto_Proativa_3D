using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CuboQue : MonoBehaviour
{
  Rigidbody body;

  float timer, environment;
  float height, pastHigh;

  Vector3 cubePosition;

  public GameObject result;
  public Text t;

  public bool isJump;

  /*
   * Formulas Usadas
   * Tempo Total (TT) = vy/5
   * Tempo Altura Máxima (TH) = vy/10
   * DeltaX = Vx*TT
   * Altura Maxima = y0 + (Vy*TH) - (5*TH^2)
   */

  void Start()
  {
    body = GetComponent<Rigidbody>();
    Restart();
  }

  void FixedUpdate()
  {
    if (body.transform.position.y > cubePosition.y)
    {
      result.SetActive(false);
      timer = 0;
    }

    if (height != pastHigh &&!isJump)
    {
      body.position = new Vector3(
        body.position.x,
        height + cubePosition.y,
        body.position.z
      );

      pastHigh = height;
    }
    
    if(isJump)
    {
      Jump();
    }
  }

  public void Jump()
  {
    if (environment == 0)
    {
      body.AddForce(Vector3.down * 20);
      timer = Mathf.Sqrt(Mathf.Abs(height / 20));
    }
    else if (environment == 1)
    {
      body.AddForce(Vector3.down * 10);
      timer = Mathf.Sqrt(Mathf.Abs(height / 10));
    }
    else
    {
      body.AddForce(Vector3.down * 3);
      timer = Mathf.Sqrt(Mathf.Abs(height / 3));
    }
  }

  public void Restart()
  {
    SetEnvironment(1);
    body.rotation = Quaternion.Euler(0, 90, 0);

    timer = 0;
    height = 0;
    pastHigh = height;
    isJump = false;

    result.SetActive(false);
  }

  public void SetHeight(float h)
  {
    height = h;
  }

  public void SetEnvironment(float a)
  {
    environment = a;
    switch (a)
    {
      case 0:
        cubePosition = new Vector3(-262.4f, -6.69f, 94.7f);
        body.position = cubePosition;
        break;
      case 1:
        cubePosition = new Vector3(-262.4f, -6.69f, -6f);
        body.position = cubePosition;
        break;
      default:
        cubePosition = new Vector3(-262.4f, -6.69f, -116.94f);
        body.position = cubePosition;
        break;
    }
  }

  private void OnCollisionEnter(Collision collision)
  {
    Debug.Log("Entrei");
    if (timer != 0)
    {
      result.SetActive(true);
      isJump = false;
    }
  }

  private void OnGUI()
  {
    GUI.contentColor = Color.white;
    t.text = "Tempo: " + timer.ToString("0.00");
  }
}
