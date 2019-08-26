using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdicionaForca : MonoBehaviour
{
    public Rigidbody cubo;

    public void AddForca()
    {
        Vector3 forca = new Vector3(5, 0, 0);

        cubo.AddForce(forca, ForceMode.Impulse);
    }
}
