using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeStuff : MonoBehaviour
{
    private float angulo;
    private float massa;
    private float atrito;
    
    [SerializeField]
    private Vector3[] posPortal;
    [SerializeField]
    private Vector3[] posTrigger;

    public Restart restart;

    public Text textoAngulo;
    public Text textoMassa;
    public Text textoAtrito;
    public Text textoForca;

    public GameObject suporte1;
    public GameObject suporte2;
    public GameObject rampa;
    public GameObject cubo;
    public GameObject camera01;
    public GameObject camera02;
    public GameObject camera03;
    public GameObject start;
    public GameObject end;
    public GameObject portal, trigger;

    public MeshRenderer cuboMat;

    public Rigidbody rb;

    Color color;

    private void Start()
    {
        this.angulo = 20f;
        this.atrito = 0.10f;
        this.massa = 1f;

        //posPortal = new Vector3[3];
        posPortal[0] = new Vector3(portal.transform.position.x, portal.transform.position.y, portal.transform.position.z);
        posPortal[1] = new Vector3(portal.transform.position.x, portal.transform.position.y, portal.transform.position.z - 0.69f);
        posPortal[2] = new Vector3(portal.transform.position.x, portal.transform.position.y, portal.transform.position.z - 0.96f);

        //posTrigger = new Vector3[3];
        posTrigger[0] = new Vector3(trigger.transform.position.x, trigger.transform.position.y, trigger.transform.position.z);
        posTrigger[1] = new Vector3(trigger.transform.position.x, trigger.transform.position.y, trigger.transform.position.z - 0.69f);
        posTrigger[2] = new Vector3(trigger.transform.position.x, trigger.transform.position.y, trigger.transform.position.z - 0.96f);

        SetAngleText(20f);
        UpdateProperties(20f);

        suporte1.SetActive(true);
        suporte2.SetActive(false);

        rb = cubo.gameObject.GetComponent<Rigidbody>();;
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
            restart.SetPosInicial(pos, cubo.transform.rotation);
            cubo.transform.localScale = sca;
            //

            //Setando o PORTAL:
            portal.transform.position = posPortal[0];
            trigger.transform.position = posTrigger[0];
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
            restart.SetPosInicial(pos, cubo.transform.rotation);
            cubo.transform.localScale = sca;
            //

            //Setando o PORTAL:
            portal.transform.position = posPortal[0];
            trigger.transform.position = posTrigger[0];
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
            restart.SetPosInicial(pos, cubo.transform.rotation);
            cubo.transform.localScale = sca;
            //

            //Setando o PORTAL:
            portal.transform.position = posPortal[1];
            trigger.transform.position = posTrigger[1];
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
            restart.SetPosInicial(pos, cubo.transform.rotation);
            cubo.transform.localScale = sca;
            //
            
            //Setando o PORTAL:
            portal.transform.position = posPortal[2];
            trigger.transform.position = posTrigger[2];
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
        rb.AddForce(new Vector3(0, -(m * 10), 0), ForceMode.Acceleration);

        color = cuboMat.sharedMaterial.color;

        color.r = (1.5f / m);
        color.g = (3.5f / m) / 2;
        color.b = (1.8f / m);

        cuboMat.sharedMaterial.color = color;
        cuboMat.sharedMaterial.SetColor("_Color", color);
    }

    public void ChangeMassText()
    {
        textoMassa.text = "Massa: " + this.massa + " kg";
    }

    public void ChangeFriction(float a)
    {
        if(a == 1)
        {
            this.atrito = 0.10f;
            ChangeFrictionText(this.atrito);

            rampa.gameObject.GetComponent<BoxCollider>().material.dynamicFriction = this.atrito;
            rampa.gameObject.GetComponent<BoxCollider>().material.staticFriction = this.atrito;
        }
        else if (a == 2)
        {
            this.atrito = 0.12f;
            ChangeFrictionText(this.atrito);

            rampa.gameObject.GetComponent<BoxCollider>().material.dynamicFriction = this.atrito;
            rampa.gameObject.GetComponent<BoxCollider>().material.staticFriction = this.atrito;
        }
        else if (a == 3)
        {
            this.atrito = 0.14f;
            ChangeFrictionText(this.atrito);

            rampa.gameObject.GetComponent<BoxCollider>().material.dynamicFriction = this.atrito;
            rampa.gameObject.GetComponent<BoxCollider>().material.staticFriction = this.atrito;
        }
        else if(a == 4)
        {
            this.atrito = 0.16f;
            ChangeFrictionText(this.atrito);

            rampa.gameObject.GetComponent<BoxCollider>().material.dynamicFriction = this.atrito;
            rampa.gameObject.GetComponent<BoxCollider>().material.staticFriction = this.atrito;
        }
        else if(a == 5)
        {
            this.atrito = 0.18f;
            ChangeFrictionText(this.atrito);

            rampa.gameObject.GetComponent<BoxCollider>().material.dynamicFriction = this.atrito;
            rampa.gameObject.GetComponent<BoxCollider>().material.staticFriction = this.atrito;
        }
        else if(a == 6)
        {
            this.atrito = 0.20f;
            ChangeFrictionText(this.atrito);

            rampa.gameObject.GetComponent<BoxCollider>().material.dynamicFriction = this.atrito;
            rampa.gameObject.GetComponent<BoxCollider>().material.staticFriction = this.atrito;
        }
        else if(a == 7)
        {
            this.atrito = 0.22f;
            ChangeFrictionText(this.atrito);

            rampa.gameObject.GetComponent<BoxCollider>().material.dynamicFriction = this.atrito;
            rampa.gameObject.GetComponent<BoxCollider>().material.staticFriction = this.atrito;
        }
        else if(a == 8)
        {
            this.atrito = 0.24f;
            ChangeFrictionText(this.atrito);

            rampa.gameObject.GetComponent<BoxCollider>().material.dynamicFriction = this.atrito;
            rampa.gameObject.GetComponent<BoxCollider>().material.staticFriction = this.atrito;
        }
        else if(a == 9)
        {
            this.atrito = 0.26f;
            ChangeFrictionText(this.atrito);

            rampa.gameObject.GetComponent<BoxCollider>().material.dynamicFriction = this.atrito;
            rampa.gameObject.GetComponent<BoxCollider>().material.staticFriction = this.atrito;
        }
        else if(a == 10)
        {
            this.atrito = 0.28f;
            ChangeFrictionText(this.atrito);

            rampa.gameObject.GetComponent<BoxCollider>().material.dynamicFriction = this.atrito;
            rampa.gameObject.GetComponent<BoxCollider>().material.staticFriction = this.atrito;
        }
        else if(a == 11)
        {
            this.atrito = 0.30f;
            ChangeFrictionText(this.atrito);

            rampa.gameObject.GetComponent<BoxCollider>().material.dynamicFriction = this.atrito;
            rampa.gameObject.GetComponent<BoxCollider>().material.staticFriction = this.atrito;
        }
        else if(a == 12)
        {
            this.atrito = 0.32f;
            ChangeFrictionText(this.atrito);

            rampa.gameObject.GetComponent<BoxCollider>().material.dynamicFriction = this.atrito;
            rampa.gameObject.GetComponent<BoxCollider>().material.staticFriction = this.atrito;
        }
        else if(a == 13)
        {
            this.atrito = 0.34f;
            ChangeFrictionText(this.atrito);

            rampa.gameObject.GetComponent<BoxCollider>().material.dynamicFriction = this.atrito;
            rampa.gameObject.GetComponent<BoxCollider>().material.staticFriction = this.atrito;
        }
        else if(a == 14)
        {
            this.atrito = 0.38f;
            ChangeFrictionText(this.atrito);

            rampa.gameObject.GetComponent<BoxCollider>().material.dynamicFriction = this.atrito;
            rampa.gameObject.GetComponent<BoxCollider>().material.staticFriction = this.atrito;
        }
        else if(a == 15)
        {
            this.atrito = 0.40f;
            ChangeFrictionText(this.atrito);

            rampa.gameObject.GetComponent<BoxCollider>().material.dynamicFriction = this.atrito;
            rampa.gameObject.GetComponent<BoxCollider>().material.staticFriction = this.atrito;
        }
        else if(a == 16)
        {
            this.atrito = 0.42f;
            ChangeFrictionText(this.atrito);

            rampa.gameObject.GetComponent<BoxCollider>().material.dynamicFriction = this.atrito;
            rampa.gameObject.GetComponent<BoxCollider>().material.staticFriction = this.atrito;
        }
        else if(a == 17)
        {
            this.atrito = 0.48f;
            ChangeFrictionText(this.atrito);

            rampa.gameObject.GetComponent<BoxCollider>().material.dynamicFriction = this.atrito;
            rampa.gameObject.GetComponent<BoxCollider>().material.staticFriction = this.atrito;
        }
        else if(a == 18)
        {
            this.atrito = 0.52f;
            ChangeFrictionText(this.atrito);

            rampa.gameObject.GetComponent<BoxCollider>().material.dynamicFriction = this.atrito;
            rampa.gameObject.GetComponent<BoxCollider>().material.staticFriction = this.atrito;
        }
        else if(a == 19)
        {
            this.atrito = 0.54f;
            ChangeFrictionText(this.atrito);
        
            rampa.gameObject.GetComponent<BoxCollider>().material.dynamicFriction = this.atrito;
            rampa.gameObject.GetComponent<BoxCollider>().material.staticFriction = this.atrito;
        }
        else if(a == 20)
        {
            this.atrito = 0.56f;
            ChangeFrictionText(this.atrito);

            rampa.gameObject.GetComponent<BoxCollider>().material.dynamicFriction = this.atrito;
            rampa.gameObject.GetComponent<BoxCollider>().material.staticFriction = this.atrito;
        }
        else if(a == 21)
        {
            this.atrito = 0.58f;
            ChangeFrictionText(this.atrito);

            rampa.gameObject.GetComponent<BoxCollider>().material.dynamicFriction = this.atrito;
            rampa.gameObject.GetComponent<BoxCollider>().material.staticFriction = this.atrito;
        }
        else if(a == 22)
        {
            this.atrito = 0.60f;
            ChangeFrictionText(this.atrito);

            rampa.gameObject.GetComponent<BoxCollider>().material.dynamicFriction = this.atrito;
            rampa.gameObject.GetComponent<BoxCollider>().material.staticFriction = this.atrito;
        }
        else if(a == 23)
        {
            this.atrito = 0.62f;
            ChangeFrictionText(this.atrito);

            rampa.gameObject.GetComponent<BoxCollider>().material.dynamicFriction = this.atrito;
            rampa.gameObject.GetComponent<BoxCollider>().material.staticFriction = this.atrito;
        }
        else if(a == 24)
        {
            this.atrito = 0.64f;
            ChangeFrictionText(this.atrito);

            rampa.gameObject.GetComponent<BoxCollider>().material.dynamicFriction = this.atrito;
            rampa.gameObject.GetComponent<BoxCollider>().material.staticFriction = this.atrito;
        }
        else if(a == 25)
        {
            this.atrito = 0.66f;
            ChangeFrictionText(this.atrito);

            rampa.gameObject.GetComponent<BoxCollider>().material.dynamicFriction = this.atrito;
            rampa.gameObject.GetComponent<BoxCollider>().material.staticFriction = this.atrito;
        }
        else if(a == 26)
        {
            this.atrito = 0.70f;
            ChangeFrictionText(this.atrito);

            rampa.gameObject.GetComponent<BoxCollider>().material.dynamicFriction = this.atrito;
            rampa.gameObject.GetComponent<BoxCollider>().material.staticFriction = this.atrito;
        }
    }

    public void ChangeForce(float v)
    {
        ChangeForceText(v);
    }

    public void ChangeForceText(float v)
    {
        textoForca.text = "Forca: " + v.ToString("F2");
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
