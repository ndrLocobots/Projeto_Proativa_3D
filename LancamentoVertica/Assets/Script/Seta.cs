using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seta : MonoBehaviour
{
    public float angulo, aux;
    public GameObject seta;
    public Transform body;

    void FixedUpdate()
    {
        aux = seta.transform.rotation.eulerAngles.z - 90; // ajuste do angulo com a seta
        if (aux < 0)
        {
            aux = aux + 360;
        }

        // ajuste para não ter angulo negativo
        if (aux < angulo - 1 || aux > angulo + 1)
        {  // pegando o com variação de +-1
            seta.transform.RotateAround(body.position, new Vector3(0, 0, +50), 1f);

        }
    }

    public void SetAngulo(float a)
    {
        angulo = a;
    }
}
