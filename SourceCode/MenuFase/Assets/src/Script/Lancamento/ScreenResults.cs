using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenResults : MonoBehaviour
{
    public Text Ttime, TmaxHigh, TdeltaX, Tpontuacao;
    public Text Tangle, Tvelocity, TVCorreta, TACorreto, TVUsu, TAUsu;

    private Vector3 userVelocity;
    private float totalTimer, maxHeight, DeltaX;
    private float velocity, angle, auxVel, auxAng;

    [SerializeField]
    private Tutorial tutorial;

    public float pontTotal;
    public float anguloC, velocidadeC;

    public void SetVelocity(float velocity)
    {
        this.velocity = velocity;
    }

    public void SetAngle(float angle)
    {
        this.angle = angle;
    }

    public Vector3 SetUserVelocity()
    {
        float anguloRad = Mathf.PI * angle / 180;

        userVelocity.x = Mathf.Cos(anguloRad) * velocity;
        userVelocity.y = Mathf.Sin(anguloRad) * velocity;

        return userVelocity;
    }

    public void SetOutputParam()
    {
        SetTotalTime();
        SetDeltaX();
        SetMaxHigh();

        if (!tutorial.isTutorial)
            SetPontuacao();
    }

    void SetTotalTime()
    {
        // y = y0 + v0*T + at²/2
        // where y = y0 = 0 and a = 10

        totalTimer = userVelocity.y / 5;
    }

    void SetDeltaX()
    {
        // x = x0 + vT

        DeltaX = userVelocity.x * totalTimer;
    }

    void SetMaxHigh()
    {
        // y = y0 + v0*t + at²/2
        // where y is max when t = totalTimer/2

        float time = totalTimer / 2;
        maxHeight = (userVelocity.y * time) - (5 * time * time);
    }

    void SetPontuacao()
    {
        auxVel = velocity;
        auxAng = angle;

        float pontAng;
        float pontVel;
        float maior, menor;

        if (auxVel > velocidadeC)
        {
            maior = auxVel;
            menor = velocidadeC;
        }
        else
        {
            maior = velocidadeC;
            menor = auxVel;
        }

        float erro = maior - menor;
        float x = (10 * erro) / velocidadeC;
        pontVel = 10 - x;

        if (auxAng > anguloC)
        {
            maior = auxAng;
            menor = anguloC;
        }
        else
        {
            maior = anguloC;
            menor = auxAng;
        }

        erro = maior - menor;
        x = (10 * erro) / anguloC;
        pontAng = 10 - x;

        pontTotal = (pontAng + pontVel) / 2;

        if (pontTotal < 0)
            pontTotal = 0;
    }

    private void OnGUI()
    {
        Tangle.text = angle.ToString("0") + "º";
        Tvelocity.text = velocity.ToString("0") + " m/s";
    }

    public void UpdateResultsText(bool acerto)
    {
        Ttime.text = "Tempo: " + totalTimer.ToString("0.00") + " s";
        TmaxHigh.text = "Altura máxima: " + maxHeight.ToString("0.00") + " m";
        TdeltaX.text = "Distância horizontal: " + DeltaX.ToString("0.00") + " m";

        if (!tutorial.isTutorial)
        {
            if (acerto)
            {
                TVCorreta.text = "Resposta Correta: Velocidade -  " + velocidadeC.ToString("0.00") + " m/s";
                TACorreto.text = "                                   Ângulo -  " + anguloC.ToString("0") + "º";
            }
            else
            {
                pontTotal -= 4.0f;
                TVCorreta.text = "Resposta Correta: Velocidade -  ";
                TACorreto.text = "                                   Ângulo -  ";
            }
            Tpontuacao.text = "Sua pontuação: " + pontTotal.ToString("0.0");
            TVUsu.text = "Sua resposta:         Velocidade -  " + auxVel.ToString("0.00") + " m/s";
            TAUsu.text = "                                   Ângulo -  " + auxAng.ToString("0") + "º";
        }
    }
}
