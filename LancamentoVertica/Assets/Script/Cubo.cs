using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubo : MonoBehaviour
{
    Rigidbody body;
    float velocidade;
    float angulo, anguloRad;
    public float time, MaxHeight, DeltaX;
    bool jumper, clook;
    Vector3 velo, StPosition;

    void Start()
    {
        body = GetComponent<Rigidbody>();

        body.freezeRotation = true;
        jumper = true;
        clook = false;

        StPosition = new Vector3(-262.4f, -9.492697f, -6f);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (velocidade != 0)
            {
                if (angulo > 0 && angulo < 90)
                {
                    Pular(jumper);
                    jumper = false;
                }
            }

        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            body.velocity = new Vector3(0, 0, 0);
            body.position = StPosition;
            jumper = true;
            time = 0;
            MaxHeight = 0;
        }
    }

    void FixedUpdate()
    {
        if (clook)
        {
            time++;
            if (MaxHeight == 0)
            {
                MaxHeight = AlturaMaxima();
            }
        }
    }

    public void Pular(bool j)
    {
        if (j)
        {
            clook = true;
            anguloRad = Mathf.PI * angulo / 180; // transformando o angulo em radiano
            velo.x = Mathf.Cos(anguloRad) * velocidade;
            velo.y = Mathf.Sin(anguloRad) * velocidade;
            velo.z = body.velocity.z;
            body.velocity = velo;
        }
    }

    public float AlturaMaxima()
    {
        if ((body.velocity.y < 0.1) && (body.velocity.y > -0.1))
        { // se a velocidade do corpo for quase zero
            return (body.transform.position.y - StPosition.y) * 1.04f; // adiciona 4% para compensar erro
        }
        else
        {
            return 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        body.velocity = new Vector3(0, 0, 0);
        clook = false;
        time = time / 60;
        DeltaX = body.position.x - StPosition.x;
    }

    public void SetVelocidade(float v)
    {
        velocidade = v;
    }
    public void SetAngulo(float a)
    {
        angulo = a;
    }

    private void OnGUI()
    {
        GUI.contentColor = Color.black;
        GUI.Label(new Rect(300, 10, 200, 200), angulo.ToString("0"));

        GUI.contentColor = Color.black;
        GUI.Label(new Rect(10, 80, 200, 60), "TEMPO:");
        GUI.Label(new Rect(100, 80, 200, 30), time.ToString("0.00"));
        GUI.Label(new Rect(10, 110, 200, 60), "ALTURA-MAX");
        GUI.Label(new Rect(100, 110, 200, 30), MaxHeight.ToString("0.000"));
        GUI.Label(new Rect(10, 140, 200, 60), "DELTA-X");
        GUI.Label(new Rect(100, 140, 200, 30), DeltaX.ToString("0.000"));
    }
}
