using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CuboFor : MonoBehaviour
{

    struct FisicaMaterial
    {
        public float staticFriction;
        public float dynamicFriction;
    } 


    Rigidbody body;
    float forca, forcaAtritoDin, forcaAtritoEst, faux, aceleracao;
    Vector3 velo, StPosition;
    FisicaMaterial atrito;
    bool buttom, restart;
    public GameObject result;
    public Text a, fad, fae, mas, forc;

    /*
     * Formulas Usadas
     * Tempo Total (TT) = vy/5
     * Tempo Altura Máxima (TH) = vy/10
     * DeltaX = Vx*TT
     * Altura Maxima = y0 + (Vy*TH) - (5*TH^2)
     */

    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.freezeRotation = true;
        StPosition = new Vector3(-241.8f, -9f, -2.5f);
        buttom = false;
        restart = false;

        atrito.staticFriction = 0;
        atrito.dynamicFriction = 0;
        result.SetActive(false);
    }

    void Update()
    {
        forcaAtritoDin = body.mass * 9.8f * atrito.dynamicFriction;
        forcaAtritoEst = body.mass * 9.8f * atrito.staticFriction;
        if (Input.GetKeyDown(KeyCode.O) || restart)
        {
            body.velocity = new Vector3(0, 0, 0);
            body.position = StPosition;
            buttom = false;
            restart = false;

        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            result.SetActive(!result.active);

        }
    }

    private void FixedUpdate()
    {
        if (buttom)
        {
            faux = forca - forcaAtritoEst;
            if ((body.velocity.x == 0 && faux <= 0) || body.velocity.x < 0) {
                faux = 0;
                body.velocity = Vector3.zero;
                aceleracao = 0;
            }
            else
            {
                faux = forca - forcaAtritoDin;
                body.AddForce((faux) * Vector3.right);
                aceleracao = faux / body.mass;

            }
            
            
        }
    }
    public  void ClickButtom(bool b)
    {
        buttom = true;
        
    }

    public void ClickButtom2(bool b)
    {
        restart = true;

    }

    public void SetForça(float f)
    {
        forca = f;
    }

    public void SetMassa(float m)
    {
        body.mass = m;
    }

    public void SetAtritoDinamico(float a)
    {
        atrito.dynamicFriction = a;
    }

    public void SetAtritoEstatico(float a)
    {
        atrito.staticFriction = a;
    }

    private void OnCollisionEnter(Collision collision)
    {
       
    }
    

    private void OnGUI()
    {
        
        /*
        GUI.Label(new Rect(10, 110, 200, 60), "Forca Atrito Dinamico");
        GUI.Label(new Rect(150, 110, 200, 30), forcaAtritoDin.ToString("0.00"));
        
        GUI.Label(new Rect(10, 140, 200, 60), "Forca Atrito Estatico");
        GUI.Label(new Rect(150, 140, 200, 30), forcaAtritoEst.ToString("0.00"));

        GUI.Label(new Rect(10, 170, 200, 60), "Aceleração");
        GUI.Label(new Rect(100, 170, 200, 30), aceleracao.ToString("0.00"));
        */
        mas.text = body.mass.ToString("0");
        forc.text = forca.ToString("0");
        a.text = "Aceleração do cubo: " + aceleracao.ToString("0.00");
        fad.text = atrito.dynamicFriction.ToString("0.00");
        fae.text = atrito.staticFriction.ToString("0.00");





    }
}
