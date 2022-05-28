using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleVelCubo : MonoBehaviour
{
    public GameObject cubo;
    public Rigidbody cuboR;
    private double posInic, posAtu;
    public Text velocimetro;
    public ArrastaCubo arCub;

    void Start()
    {
        posInic = cubo.transform.position.x;
        Velocimetro(0);
    }

    void Update()
    {
        posAtu = cubo.transform.position.x;

        if (posAtu != posInic && cuboR.velocity.x != 0 && !arCub.GetDrag())
            Velocimetro(GetVelocidade());
        else
            Velocimetro(0.0);
            
    }

    private double GetVelocidade()
    {
        return cuboR.velocity.x * -1;
    }

    public void Velocimetro(double velocidade)
    {
        velocimetro.text = "Velocidade: " + velocidade.ToString("F2") + "  m/s";
    }
}
