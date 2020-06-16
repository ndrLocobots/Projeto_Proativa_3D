using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class position : MonoBehaviour
{
  public Transform personagem;
  private Transform positionCamera;
  float aux;
  // Start is called before the first frame update
  void Start()
  {
    aux = 0;
    positionCamera = GetComponent<Transform>();
  }

  // Update is called once personagem frame
  void Update()
  {

    switch (aux)
    {
      case 0:
        positionCamera.position = new Vector3(personagem.position.x, personagem.position.y + 1, personagem.position.z);
        break;
      case 1:
        positionCamera.position = new Vector3(personagem.position.x - 10, personagem.position.y + 10, personagem.position.z);
        break;
      case 2:
        positionCamera.position = new Vector3(personagem.position.x, personagem.position.y + 10, personagem.position.z - 20);
        break;
      default:
        aux = 0;
        break;

    }

  }

  public void SliderAux(float parametro)
  {
    aux = parametro;
  }
}
