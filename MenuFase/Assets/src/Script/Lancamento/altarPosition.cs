using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class altarPosition : MonoBehaviour
{

  public float deltaDistance;
  public bool x, y, z;

  Vector3 startPoint, distanceDirection;
  void Start()
  {
    if (x)
    {
      distanceDirection = new Vector3(1, 0, 0);
    }
    else if (y)
    {
      distanceDirection = new Vector3(0, 1, 0);
    }
    else if (z)
    {
      distanceDirection = new Vector3(0, 0, 1);
    }

    startPoint = transform.position;
    distanceDirection = distanceDirection * deltaDistance;
  }

  public void ChangeAltarPosition()
  {
    float porcentagem = Random.Range(0.0f, 1.0f);
    transform.position = startPoint + distanceDirection * porcentagem;
  }

}
