using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeStuff : MonoBehaviour
{
    private float angulo;
    private float massa;
    private float atrito;

    public Text textoAngulo;
    public Text textoMassa;
    public Text textoAtrito;

    public GameObject suporte1;
    public GameObject suporte2;
    public GameObject rampa;
    public GameObject cubo;
    public GameObject camera01;
    public GameObject camera02;
    public GameObject camera03;
    public GameObject start;
    public GameObject end;

    public MeshRenderer cuboMat;

    public Rigidbody rb;

    private void Start()
    {
        this.angulo = 20f;
        this.atrito = 0.10f;
        this.massa = 1f;

        SetAngleText(20f);
        UpdateProperties(20f);

        suporte1.SetActive(true);
        suporte2.SetActive(false);

        rb = cubo.gameObject.GetComponent<Rigidbody>();
    }

    public void SetAngle(float a)
    {
        if(a == 0)
        {
            this.angulo = 20f;
            SetAngleText(20f);
            UpdateProperties(20f);
        }
        if(a == 1)
        {
            this.angulo = 30f;
            SetAngleText(30f);
            UpdateProperties(30f);
        }
        if(a == 2)
        {
            this.angulo = 45f;
            SetAngleText(45f);
            UpdateProperties(45f);
        }
        if(a == 3)
        {
            this.angulo = 60f;
            SetAngleText(60f);
            UpdateProperties(60f);
        }
    }

    public void SetAngleText(float a)
    {
        textoAngulo.text = "Ângulo: " + a.ToString() + "º";
    }

    public void UpdateProperties(float angle)
    {
        if(angle == 20)
        {
            suporte1.SetActive(true);
            suporte2.SetActive(false);

            //Setando o SUPORTE:
            Vector3 pos = new Vector3(7.59f, 10.23f, -25.46f);
            Vector3 sca = new Vector3(1.3681f, 1.3681f, 1.3681f);

            suporte1.transform.position = pos;
            suporte1.transform.rotation = Quaternion.Euler(0, 0, 0);
            suporte1.transform.localScale = sca;
            //

            //Setando a RAMPA:
            pos.Set(7.6f, 10.27f, -22.95f);
            sca.Set(0.5f, 0.07f, 4f);
   
            rampa.transform.position = pos;
            rampa.transform.rotation = Quaternion.Euler(20, 0, 0);
            rampa.transform.localScale = sca;
            //

            //Setando o CUBO:
            pos.Set(7.605f, 11.07f, -24.49f);
            sca.Set(0.37038f, 0.37038f, 0.37038f);

            cubo.transform.position = pos;
            cubo.transform.rotation = Quaternion.Euler(20, 0, 0);
            cubo.transform.localScale = sca;
            //

            //Setando a CAMERA 01:
            Vector3 posCamera = new Vector3(10.05f, 11.74f, -23.12f);
            sca.Set(1f, 1f, 1f);

            camera01.transform.position = posCamera;
            camera01.transform.rotation = Quaternion.Euler(28.802f, -89.769f, 0.111f);
            camera01.transform.localScale = sca;
            //

            //Setando a CAMERA 02:
            posCamera.Set(5.53f, 11.93f, -21.19f);
            sca.Set(1f, 1f, 1f);

            camera02.transform.position = posCamera;
            camera02.transform.rotation = Quaternion.Euler(35.541f, 137.576f, -1.553f);
            camera02.transform.localScale = sca;
            //

            //Setando a CAMERA 03:
            posCamera.Set(7.62f, 11.73f, -25.16f);
            sca.Set(1f, 1f, 1f);

            camera03.transform.position = posCamera;
            camera03.transform.rotation = Quaternion.Euler(42.842f, -1.715f, -2.527f);
            camera03.transform.localScale = sca;
            //

            //Setando o START:
            pos.Set(7.605f, 11.197f, -24.812f);
            sca.Set(0.37038f, 0.37038f, 0.37038f);

            start.transform.position = pos;
            start.transform.rotation = Quaternion.Euler(20, 0, 0);
            start.transform.localScale = sca;
            //

            //Setando o END:
            pos.Set(7.605f, 9.776f, -20.853f);
            sca.Set(0.37038f, 0.37038f, 0.37038f);

            end.transform.position = pos;
            end.transform.rotation = Quaternion.Euler(20, 0, 0);
            end.transform.localScale = sca;
            //
        }
        if (angle == 30)
        {
            suporte1.SetActive(true);
            suporte2.SetActive(false);

            //DEBUG: rampa.transform.position = new Vector3(2f, 2f, 2f);

            //Setando o SUPORTE:
            Vector3 pos = new Vector3(7.59f, 10.23f, -25.46f);
            Vector3 sca = new Vector3(2f, 2f, 2f);

            suporte1.transform.position = pos;
            suporte1.transform.rotation = Quaternion.Euler(0, 0, 0);
            suporte1.transform.localScale = sca;
            //

            //Setando a RAMPA:
            pos.Set(7.62f, 10.57f, -22.71f);
            sca.Set(0.5f, 0.07f, 4.0724f);

            rampa.transform.position = pos;
            rampa.transform.rotation = Quaternion.Euler(30, 0, 0);
            rampa.transform.localScale = sca;
            //

            //Setando o CUBO:
            pos.Set(7.627f, 11.621f, -24.079f);
            sca.Set(0.37038f, 0.37038f, 0.37038f);

            cubo.transform.position = pos;
            cubo.transform.rotation = Quaternion.Euler(30, 0, 0);
            cubo.transform.localScale = sca;
            //

            //Setando a CAMERA 01:
            Vector3 posCamera = new Vector3(10.57f, 12.39f, -23.12f);
            sca.Set(1f, 1f, 1f);

            camera01.transform.position = posCamera;
            camera01.transform.rotation = Quaternion.Euler(28.802f, -89.769f, 0.111f);
            camera01.transform.localScale = sca;
            //

            //Setando a CAMERA 02:
            posCamera.Set(5.53f, 12.79f, -20.5f);
            sca.Set(1f, 1f, 1f);

            camera02.transform.position = posCamera;
            camera02.transform.rotation = Quaternion.Euler(35.541f, 137.576f, -1.553f);
            camera02.transform.localScale = sca;
            //

            //Setando a CAMERA 03:
            posCamera.Set(7.62f, 12.3f, -24.69f);
            sca.Set(1f, 1f, 1f);

            camera03.transform.position = posCamera;
            camera03.transform.rotation = Quaternion.Euler(42.842f, -1.715f, -2.527f);
            camera03.transform.localScale = sca;
            //

            //Setando o START:
            pos.Set(7.605f, 11.749f, -24.412f);
            sca.Set(0.37038f, 0.37038f, 0.37038f);

            start.transform.position = pos;
            start.transform.rotation = Quaternion.Euler(30, 0, 0);
            start.transform.localScale = sca;
            //

            //Setando o END:
            pos.Set(7.82f, 9.71f, -20.72f);
            sca.Set(0.37038f, 0.37038f, 0.37038f);

            end.transform.position = pos;
            end.transform.rotation = Quaternion.Euler(20, 0, 0);
            end.transform.localScale = sca;
            //
        }
        if (angle == 45)
        {
            suporte1.SetActive(false);
            suporte2.SetActive(true);

            //Setando o SUPORTE:
            Vector3 pos = new Vector3(7.59f, 10.95f, -25.06f);
            Vector3 sca = new Vector3(1.075f, 2.82843f, 1.025f);

            suporte2.transform.position = pos;
            suporte2.transform.rotation = Quaternion.Euler(0, 0, 0);
            suporte2.transform.localScale = sca;
            //

            //Setando a RAMPA:
            pos.Set(7.6f, 10.98f, -23.11f);
            sca.Set(0.5f, 0.07f, 4f);

            rampa.transform.position = pos;
            rampa.transform.rotation = Quaternion.Euler(45, 0, 0);
            rampa.transform.localScale = sca;
            //

            //Setando o CUBO:
            pos.Set(7.605f, 12.382f, -24.176f);
            sca.Set(0.37038f, 0.37038f, 0.37038f);

            cubo.transform.position = pos;
            cubo.transform.rotation = Quaternion.Euler(45, 0, 0);
            cubo.transform.localScale = sca;
            //

            //Setando a CAMERA 01:
            Vector3 posCamera = new Vector3(10.92f, 13.37f, -23.27f);
            sca.Set(1f, 1f, 1f);

            camera01.transform.position = posCamera;
            camera01.transform.rotation = Quaternion.Euler(28.802f, -89.769f, 0.111f);
            camera01.transform.localScale = sca;
            //

            //Setando a CAMERA 02:
            posCamera.Set(5.78f, 13.32f, -20.87f);
            sca.Set(1f, 1f, 1f);

            camera02.transform.position = posCamera;
            camera02.transform.rotation = Quaternion.Euler(34.429f, 127.383f, -11.953f);
            camera02.transform.localScale = sca;
            //

            //Setando a CAMERA 03:
            posCamera.Set(7.568f, 13.42f, -24.658f);
            sca.Set(1f, 1f, 1f);

            camera03.transform.position = posCamera;
            camera03.transform.rotation = Quaternion.Euler(49.087f, -1.92f, -2.812f);
            camera03.transform.localScale = sca;
            //

            //Setando o START:
            pos.Set(7.605f, 12.586f, -24.47f);
            sca.Set(0.37038f, 0.37038f, 0.37038f);

            start.transform.position = pos;
            start.transform.rotation = Quaternion.Euler(45, 0, 0);
            start.transform.localScale = sca;
            //

            //Setando o END:
            pos.Set(7.605f, 9.521f, -21.622f);
            sca.Set(0.37038f, 0.37038f, 0.37038f);

            end.transform.position = pos;
            end.transform.rotation = Quaternion.Euler(45, 0, 0);
            end.transform.localScale = sca;
            //

        }
        if (angle == 60)
        {
            suporte1.SetActive(false);
            suporte2.SetActive(true);

            //Setando o SUPORTE:
            Vector3 pos = new Vector3(7.59f, 11.25f, -25.06f);
            Vector3 sca = new Vector3(1.075f, 3.4641f, 1.025f);

            suporte2.transform.position = pos;
            suporte2.transform.rotation = Quaternion.Euler(0, 0, 0);
            suporte2.transform.localScale = sca;
            //

            //Setando a RAMPA:
            pos.Set(7.6f, 11.3f, -23.53f);
            sca.Set(0.5f, 0.07f, 4f);

            rampa.transform.position = pos;
            rampa.transform.rotation = Quaternion.Euler(60, 0, 0);
            rampa.transform.localScale = sca;
            //

            //Setando o CUBO:
            pos.Set(7.605f, 12.92f, -24.217f);
            sca.Set(0.37038f, 0.37038f, 0.37038f);

            cubo.transform.position = pos;
            cubo.transform.rotation = Quaternion.Euler(60, 0, 0);
            cubo.transform.localScale = sca;
            //

            //Setando a CAMERA 01:
            Vector3 posCamera = new Vector3(10.51f, 13.75f, -23.79f);
            sca.Set(1f, 1f, 1f);

            camera01.transform.position = posCamera;
            camera01.transform.rotation = Quaternion.Euler(31.244f, -86.82301f, 2.894f);
            camera01.transform.localScale = sca;
            //

            //Setando a CAMERA 02:
            posCamera.Set(5.22f, 14.18f, -21.99f);
            sca.Set(1f, 1f, 1f);

            camera02.transform.position = posCamera;
            camera02.transform.rotation = Quaternion.Euler(38.224f, 123.035f, -19.376f);
            camera02.transform.localScale = sca;
            //

            //Setando a CAMERA 03:
            posCamera.Set(7.568f, 13.76f, -24.54f);
            sca.Set(1f, 1f, 1f);

            camera03.transform.position = posCamera;
            camera03.transform.rotation = Quaternion.Euler(63.36f, -2.805f, -3.868f);
            camera03.transform.localScale = sca;
            //
        }
    }

    public void ChangeMass(float m)
    {
        this.massa = m;
        ChangeMassText();
        rb.mass = m;

        Color color = cuboMat.material.color;

        color.r = (1.5f / m);
        color.g = (3.5f / m) / 2;
        color.b = (1.8f / m);

        cuboMat.material.color = color;
        cuboMat.material.SetColor("_Color", color);
    }

    public void ChangeMassText()
    {
        textoMassa.text = "Massa: " + this.massa + " kg";
    }

    public void ChangeFriction(float a)
    {
        if (a == 1)
        {
            rampa.gameObject.GetComponent<BoxCollider>().material.dynamicFriction = 0.12f;
            rampa.gameObject.GetComponent<BoxCollider>().material.staticFriction = 0.12f;

            ChangeFrictionText(0.10f);
            this.atrito = 0.10f;
        }
        if (a == 2)
        {
            rampa.gameObject.GetComponent<BoxCollider>().material.dynamicFriction = 0.18f;
            rampa.gameObject.GetComponent<BoxCollider>().material.staticFriction = 0.18f;

            ChangeFrictionText(0.15f);
            this.atrito = 0.15f;
        }
        if (a == 3)
        {
            rampa.gameObject.GetComponent<BoxCollider>().material.dynamicFriction = 0.20f;
            rampa.gameObject.GetComponent<BoxCollider>().material.staticFriction = 0.20f;

            ChangeFrictionText(0.20f);
            this.atrito = 0.20f;
        }
        if(a == 4)
        {
            rampa.gameObject.GetComponent<BoxCollider>().material.dynamicFriction = 0.30f;
            rampa.gameObject.GetComponent<BoxCollider>().material.staticFriction = 0.30f;

            ChangeFrictionText(0.30f);
            this.atrito = 0.30f;
        }
        if(a == 5)
        {
            rampa.gameObject.GetComponent<BoxCollider>().material.dynamicFriction = 0.40f;
            rampa.gameObject.GetComponent<BoxCollider>().material.staticFriction = 0.40f;

            ChangeFrictionText(0.40f);
            this.atrito = 0.40f;
        }
            
    }
    public void ChangeFrictionText(float v)
    {
        textoAtrito.text = "Atrito: " + v;
    }

    public float GetAngulo()
    {
        return this.angulo;
    }
    public float GetMassa()
    {
        return this.massa;
    }
    public float GetAtrito()
    {
        return this.atrito;
    }
}
