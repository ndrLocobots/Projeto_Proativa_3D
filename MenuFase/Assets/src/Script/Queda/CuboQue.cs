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

  public float[] gravities = new float[] { 20, 10, 3 };

  void Start()
  {
    body = GetComponent<Rigidbody>();
    Restore();
  }

  void FixedUpdate()
  {
    if (height != pastHigh && !isJump)
    {
      body.position = new Vector3(
        body.position.x,
        height + cubePosition.y,
        body.position.z
      );

      pastHigh = height;
    }

    if (isJump)
    {
      Jump();
    }
  }

  public void Jump()
  {
    if (environment == 0)
    {
      body.AddForce(Vector3.down * gravities[0]);
      timer = CalculateValue(height,0);
    }
    else if (environment == 1)
    {
      body.AddForce(Vector3.down * gravities[1]);
      timer = CalculateValue(height,1);
    }
    else
    {
      body.AddForce(Vector3.down * gravities[2]);
      timer = CalculateValue(height,2);
    }
  }

  public float CalculateValue(float height, int env){
    return Mathf.Sqrt(height/gravities[env]);
  }

  public void Restore()
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
        cubePosition = new Vector3(
          body.position.x,
          body.position.y,
          88.8f
          );
        body.position = cubePosition;
        break;
      case 1:
        cubePosition = new Vector3(
          body.position.x,
          body.position.y,
          -11.8f
        );
        body.position = cubePosition;
        break;
      default:
        cubePosition = new Vector3(
          body.position.x,
          body.position.y,
          -122.8f
        );
        body.position = cubePosition;
        break;
    }
  }

  private void OnCollisionEnter(Collision collision)
  {
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
