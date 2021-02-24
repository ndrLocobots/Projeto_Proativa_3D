using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleAnimacoes : MonoBehaviour
{
    private robotAnimation animRobo;
    private AnimInimigo animInimigo;
    private heart coracoes;

    //TEMPORARIO
    private float massaCorreta = 5f;
    private float atritoCorreto = 3f;
    private float anguloCorreto = 1f;

    private int contadorErros;

    void Start()
    {
        animRobo = FindObjectOfType<robotAnimation>();
        coracoes = FindObjectOfType<heart>();
        animInimigo = FindObjectOfType<AnimInimigo>();

        contadorErros = 0;
    }

    public void VerificaQuestao(float valorMassa, float valorAtrito, float valorAngulo)
    {
        Debug.Log("Massa: " + valorMassa + "Angulo: " + valorAngulo + "Atrito: " + valorAtrito);
        if(valorMassa == massaCorreta && valorAtrito == atritoCorreto && valorAngulo == anguloCorreto)
            AnimAcerto();
        else
        {
            contadorErros++;
            AnimErro(contadorErros);
        }
    }

    public void AnimAcerto()
    {
        animRobo.RobotHappy();
    }

    public void AnimErro(int tentativa)
    {
        if(tentativa == 1)
        {
            coracoes.loseHeart();
            animRobo.RobotSad();
            animInimigo.AnimaInimigo(1);
        }
        else if(tentativa == 2)
        {
            coracoes.loseHeart();
            animRobo.RobotSad();
            animInimigo.AnimaInimigo(2);
        }
        else if(tentativa == 3)
        {
            coracoes.loseHeart();
            animRobo.RobotSad();
            animInimigo.AnimaInimigo(3);
            //Animacao do cubo perdendo
        }
    }
}
