using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
  public Transform cube;
  public NavMeshAgent agent;
  Vector3 initialPosition, vectorDirectionToWalk, vectorUnitary;
  int tryAnswer = 2;

  void Start()
  {
    agent = GetComponent<NavMeshAgent>();
    initialPosition = GetComponent<Transform>().position;

    agent.speed = 20;
    agent.acceleration = 40;
  }

  public void activeEnemy()
  {
    vectorDirectionToWalk = cube.position - transform.position;
    vectorUnitary = vectorDirectionToWalk / vectorDirectionToWalk.magnitude;

    switch (tryAnswer)
    {
      case 2:
        agent.SetDestination(transform.position + 20 * vectorUnitary);
        break;

      case 1:
        agent.SetDestination(
          transform.position + vectorDirectionToWalk.magnitude * vectorUnitary / 2
        );
        break;

      case 0:
        agent.SetDestination(cube.position);
        break;

      default:
        tryAnswer = 3;
        agent.SetDestination(initialPosition);
        break;
    }

    tryAnswer--;
  }
}
