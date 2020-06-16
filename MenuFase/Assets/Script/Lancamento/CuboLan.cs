using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CuboLan : MonoBehaviour
{
  Rigidbody body;
  float velocidade;
  float angulo, anguloRad;
  float timer, MaxHeight, DeltaX;
  public bool jumper, buttom, restart;
  Vector3 velo, StPosition;
  public GameObject result;
  public Text t, am, dx, an, vel; // tempo, altura maxima, deltax

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
    body.freezeRotation = true;

    jumper = true;
    timer = 0;
    MaxHeight = 0;
    DeltaX = 0;
    buttom = restart = false;

    StPosition = new Vector3(-262.4f, -9.492697f, -6f);
    result.SetActive(false);
  }

  void Update()
  {

    if (Input.GetKeyDown(KeyCode.Space) || buttom)
    {
      if (velocidade != 0)
      {
        if (angulo > 0 && angulo <= 90)
        {
          Pular(jumper);
          jumper = false;
          buttom = false;
        }
      }

    }

    if (Input.GetKeyDown(KeyCode.O) || restart)
    {
      body.velocity = new Vector3(0, 0, 0);
      body.position = StPosition;
      jumper = true;
      timer = 0;
      MaxHeight = 0;
      DeltaX = 0;
      result.SetActive(false);
      restart = false;
    }
  }

  public void ClickButtom(bool b)
  {
    buttom = true;
  }

  public void ClickButtom1(bool b)
  {
    restart = true;
  }

  void Pular(bool j)
  {
    if (j)
    {
      anguloRad = Mathf.PI * angulo / 180; // transformando o angulo em radiano
      velo.x = Mathf.Cos(anguloRad) * velocidade;
      velo.y = Mathf.Sin(anguloRad) * velocidade;
      velo.z = body.velocity.z;
      body.velocity = velo;
    }
  }


  float TempoTotal()
  {
    return velo.y / 5;
  }

  float TempoAlturaMaxima()
  {
    return velo.y / 10;
  }

  float DistanciaX(float t)
  {
    return velo.x * t;
  }

  float AlturaMaxima(float t)
  {
    return (velo.y * t) - (5 * t * t);
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (!jumper)
    {
      body.velocity = new Vector3(0, 0, 0);
      MaxHeight = AlturaMaxima(TempoAlturaMaxima());
      timer = TempoTotal();
      DeltaX = DistanciaX(timer);
      result.SetActive(true);
    }

  }
  public void SetVelocidade(float v)
  {
    velocidade = v;
  }
  public void SetAngulo(float a)
  {
    angulo = a;
  }

  private void OnGUI()
  {
    an.text = angulo.ToString("0");
    vel.text = velocidade.ToString("0");
    t.text = "Tempo: " + timer.ToString("0.00");
    am.text = "Altura máxima: " + MaxHeight.ToString("0.00");
    dx.text = "Distância horizontal: " + DeltaX.ToString("0.00");
  }
}
