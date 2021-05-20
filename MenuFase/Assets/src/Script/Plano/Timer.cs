using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public Text a;
    public Text v;
    public Text t;
    public SoundsAnimationP sound;

    public ChangeStuff cs;

    public GameObject results;

    private float start;
    private bool isStarted, botaoApertado;
    string minutes;
    string seconds;
    double ace, vel;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Start") && botaoApertado)
        {
            isStarted = true;

            start = Time.time;
            results.SetActive(false);
            sound.PlayCubo();
            
        }
            
        if (other.CompareTag("End"))
        {
            isStarted = false;
            botaoApertado = false;

            ShowResults();
        }
            
    }

    void Start()
    {
        start = Time.time;
        botaoApertado = false;
    }

    void Update()
    {
        if(isStarted)
        {
            float t = Time.time - start;
            minutes = ((int)t / 60).ToString();
            seconds = (t % 60).ToString("f2");

            timerText.text = "Tempo: " + minutes + ":" + seconds;
        }
    }

    private void ShowResults()
    {
        ace = CalculaAceleracao(cs.GetAtrito(), cs.GetAngulo(), cs.GetMassa());
        vel = CalculaVelocidade(ace);

        a.text = "Aceleração: " + ace.ToString("f2") + " m/s²";
        v.text = "Velocidade: " + vel.ToString("f2") + " m/s";
        t.text = timerText.text;

        results.SetActive(true);
    }

    public void HideResults()
    {
        start = Time.time;
        timerText.text = "Tempo: " + 0.ToString() + ":" + "0,00";
        results.SetActive(false);
    }

    private double CalculaAceleracao(float atrito, float angulo, float massa)
    {
        double resultado;
        double fat, pt, fres;

        //Debug.Log("atrito: " + atrito + ", angulo: " + angulo + ", massa: "+ massa);

        fat = massa * 9.8 * atrito * Mathf.Cos(angulo * (Mathf.PI / 180));
        pt = massa * 9.8 * Mathf.Sin(angulo * (Mathf.PI / 180));

        fres = pt - fat;
        resultado = fres / massa;

        //Debug.Log("Ace: " + resultado);

        return resultado;
    }

    private double CalculaVelocidade(double aceleracao)
    {
        double resultado;

        resultado = Mathf.Sqrt(2 * (float)aceleracao * 3.8f);

        //Debug.Log("Vel: " + resultado);

        return resultado;
    }

    public void SetBotaoApertado(bool valor)
    {
        this.botaoApertado = valor;
    }

    public void SetIsStarted(bool valor)
    {
        this.isStarted = valor;
    }
}
