using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CuboQue : MonoBehaviour
{
    Rigidbody body;
    float timer, hight, ambiente;
    float pastHigh;
    Vector3 StPosition0, StPosition1, StPosition2;
    public Slider altura, ambi;
    public GameObject result;
    public Text t, valuehigh;

    bool buttom, restart;

    /*
     * Formulas Usadas
     * Tempo Total (TT) = vy/5
     * Tempo Altura Máxima (TH) = vy/10
     * DeltaX = Vx*TT
     * Altura Maxima = y0 + (Vy*TH) - (5*TH^2)
     */

    void Start()
    {
        hight = 0;
        pastHigh = hight;

        body = GetComponent<Rigidbody>();
        body.rotation = Quaternion.Euler(0, 90, 0);

        timer = 0;

        StPosition0 = new Vector3(-262.4f, -6.69f, 94.7f);
        StPosition1 = new Vector3(-262.4f, -6.69f, -6f);
        StPosition2 = new Vector3(-262.4f, -6.69f, -106.7f);

        ambi.value = 1;

        result.SetActive(false);
    }

    void Update()
    {
        //Andar();
        if (pastHigh - hight != 0)
        {
            buttom = false;
            body.position = new Vector3(body.position.x, hight + StPosition0.y, body.position.z);
            pastHigh = hight;
        }
        if (body.transform.position.y > StPosition0.y)
        {
            result.SetActive(false);
        }
        if (Input.GetKey("o") || restart)
        {
            altura.value = 0;
            ambi.value = 1;
            body.position = StPosition1;
            body.rotation = Quaternion.Euler(0, 90, 0);
            ambiente = 1;
            result.SetActive(false);
            restart = false;
        }
    }

    void FixedUpdate()
    {
        if (buttom)
        {
            Pular();
        }
    }

    void Pular()
    {
        if (ambiente == 0)
        {
            body.AddForce(Vector3.down * 20);
            timer = Mathf.Sqrt( Mathf.Abs(hight / 20));
        }
        else if (ambiente == 1)
        {
            body.AddForce(Vector3.down * 10);
            timer = Mathf.Sqrt(Mathf.Abs(hight / 10));
        }
        else
        {
            body.AddForce(Vector3.down * 3);
            timer = Mathf.Sqrt(Mathf.Abs(hight / 3));
        }

    }
    public void ClickButtom(bool b)
    {
        buttom = true;
    }

    public void ClickButtom2(bool b)
    {
        restart = true;
    }

    public void SetHight(float h)
    {
        hight = h;
    }

    public void SetAmbiente(float a)
    {
        ambiente = a;
        switch (a)
        {
            case 0:
                altura.value = 0;
                body.position = StPosition0;
                break;
            case 2:
                altura.value = 0;
                body.position = StPosition2;
                break;
            default:
                altura.value = 0;
                body.position = StPosition1;
                break;
        }
    }

    void Andar()
    {

        float translate = (Input.GetAxis("Vertical") * 10) * Time.deltaTime;
        float rotate = (Input.GetAxis("Horizontal") * 20) * Time.deltaTime;

        body.transform.Translate(0, 0, translate);
        body.transform.Rotate(0, rotate, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        result.SetActive(true);
    }

    private void OnGUI()
    {
        GUI.contentColor = Color.white;
        /*
        GUI.Label(new Rect(10, 80, 200, 60), "TEMPO:");
        GUI.Label(new Rect(100, 80, 200, 30), timer.ToString("0.00"));
        */
        t.text = "Tempo: " + timer.ToString("0.00");
        valuehigh.text = hight.ToString("0.00");
    }
}
