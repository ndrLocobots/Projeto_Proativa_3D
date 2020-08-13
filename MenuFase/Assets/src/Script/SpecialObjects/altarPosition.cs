using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class altarPosition : MonoBehaviour
{

  public bool x, y, z;

  public Transform ObjectStartPoint;
  Vector3 distanceDirection, startPoint;
  void Start()
  {
    startPoint = transform.position;

    if (x)
    {
      distanceDirection = new Vector3(1, 0, 0);
      startPoint.x = ObjectStartPoint.position.x;
    }
    else if (y)
    {
      distanceDirection = new Vector3(0, 1, 0);
      startPoint.y = ObjectStartPoint.position.y;
    }
    else if (z)
    {
      distanceDirection = new Vector3(0, 0, 1);
      startPoint.z = ObjectStartPoint.position.z;
    }
  }

  public void ChangeAltarPosition(float distance)
  {
    transform.position = startPoint + distanceDirection * distance;
  }

}
