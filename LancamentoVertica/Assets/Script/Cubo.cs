using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubo : MonoBehaviour
{
    Rigidbody body;
    float velocidade;
    float angulo, anguloRad;
    Vector3 velo;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space)){
            Pular();
        }

        if(Input.GetKeyDown(KeyCode.O)){
            body.velocity = new Vector3(0,0,0);
            body.position = new Vector3(-235.76f, -4.67f,- 6);
        }
    }

    public void Pular()
    {
        anguloRad = Mathf.PI * angulo / 180; // transformando o angulo em radiano
        velo.x = Mathf.Cos(anguloRad) * velocidade;
        velo.y = Mathf.Sin(anguloRad) * velocidade;
        velo.z = body.velocity.z;
        body.velocity = velo;
    }

    public void SetVelocidade(float v)
    {
        velocidade = v;
    }
    public void SetAngulo(float a)
    {
        angulo = a;
    }
}
