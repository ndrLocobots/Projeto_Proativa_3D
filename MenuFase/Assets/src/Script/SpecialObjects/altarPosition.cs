using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class altarPosition : MonoBehaviour
{

  public bool x, y, z;

  public Transform startPoint;
  Vector3 distanceDirection;
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
  }

  public void ChangeAltarPosition(float distance)
  {
    transform.position = startPoint.position + distanceDirection * distance;
  }

}
