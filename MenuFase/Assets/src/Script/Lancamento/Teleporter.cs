using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
  public Transform referencePoint;
  public MeshRenderer cuboLan;

  private Vector3 directionVector, startPoint;
  private Animator animAltar;
  private bool fuiAtingido;

  void Start()
  {
    animAltar = GetComponent<Animator>();

    directionVector = new Vector3(1,0,0);

    startPoint = transform.position;
    startPoint.x = referencePoint.position.x;

    fuiAtingido = false;
  }

  void Update()
  {
      if(fuiAtingido)
      {
          animAltar.SetBool("FuiAtingido", true);
          fuiAtingido = false;
      }
  }

  public void ChangeTeleporterPosition(float distance)
  {
    transform.position = startPoint + directionVector * distance;
  }

  public void setAtingido(bool valor)
  {
    this.fuiAtingido = valor;
  }

  public void ativaIdle()
  {
      animAltar.SetBool("FuiAtingido", false);
  }
  
  public bool getFuiAtingido()
  {
      return this.fuiAtingido;
  }

  public void escondeCubo()
  {
      cuboLan.enabled = false;   
  }

  public void apareceCubo()
  {
      cuboLan.enabled = true;
  }
}
