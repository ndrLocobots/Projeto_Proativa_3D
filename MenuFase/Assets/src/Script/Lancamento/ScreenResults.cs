using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenResults : MonoBehaviour
{
  Vector3 userVelocity;

  public Text Ttime, TmaxHigh, TdeltaX;
  public Text Tangle, Tvelocity;

  float totalTimer, maxHeight, DeltaX;
  float velocity, angle;

  public void SetVelocity(float velocity){
    this.velocity = velocity;
  }

  public void SetAngle(float angle){
    this.angle = angle;
  }
  
  public Vector3 SetUserVelocity()
  {
    float anguloRad = Mathf.PI * angle / 180;

    userVelocity.x = Mathf.Cos(anguloRad) * velocity;
    userVelocity.y = Mathf.Sin(anguloRad) * velocity;

    return userVelocity;
  }

  public void SetOutputParam(){
    SetTotalTime();
    SetDeltaX();
    SetMaxHigh();
  }

  void SetTotalTime()
  {
    // y = y0 + v0*T + at²/2
    // where y = y0 = 0 and a = 10

    totalTimer = userVelocity.y / 5;
  }

  void SetDeltaX()
  {
    // x = x0 + vT

    DeltaX = userVelocity.x * totalTimer;
  }

  void SetMaxHigh()
  {
    // y = y0 + v0*t + at²/2
    // where y is max when t = totalTimer/2
    
    float time = totalTimer/2;
    maxHeight = (userVelocity.y * time) - (5 * time * time);
  }

  private void OnGUI()
  {
    Tangle.text = angle.ToString("0");
    Tvelocity.text = velocity.ToString("0");

    Ttime.text = "Tempo: " + totalTimer.ToString("0.00");
    TmaxHigh.text = "Altura máxima: " + maxHeight.ToString("0.00");
    TdeltaX.text = "Distância horizontal: " + DeltaX.ToString("0.00");
  }
}
