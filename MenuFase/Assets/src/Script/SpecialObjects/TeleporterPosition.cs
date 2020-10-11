using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterPosition : MonoBehaviour
{
  public Transform referencePoint;
  Vector3 directionVector, startPoint;
  void Start()
  {
    directionVector = new Vector3(1,0,0);

    startPoint = transform.position;
    startPoint.x = referencePoint.position.x;
  }

  public void ChangeTeleporterPosition(float distance)
  {
    transform.position = startPoint + directionVector * distance;
  }

}
