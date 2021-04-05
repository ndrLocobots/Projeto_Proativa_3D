using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public GameObject cubo;
    public GameObject cuboAnimacao;
    public Animator portal, gameOver;
    public Slider angulo, massa, atrito, forca;

    private Vector3 posicaoInicial;
    private Quaternion rotacaoInicial;
    private Timer timer;
    private AnimInimigo animInimigo;
    private ControleAnimacoes controleAnimacoes;
    private heart coracoes;
    private QuestionPlano questionPlano;
    private ChangeStuff resetaPosicoes;
    private ControleQuestoes controleQuestoes;

    void Start()
    {
        timer = FindObjectOfType<Timer>();
        animInimigo = FindObjectOfType<AnimInimigo>();
        controleAnimacoes = FindObjectOfType<ControleAnimacoes>();
        questionPlano = FindObjectOfType<QuestionPlano>();
        coracoes = FindObjectOfType<heart>();
        resetaPosicoes = FindObjectOfType<ChangeStuff>();
        controleQuestoes = FindObjectOfType<ControleQuestoes>();
    }

    public void SetPosInicial(Vector3 posCubo, Quaternion rotCubo)
    {
        posicaoInicial = posCubo;
        rotacaoInicial = rotCubo;
    }

    public void RestartScene()
    {
        timer.SetIsStarted(false);

        cubo.transform.position = posicaoInicial;
        cubo.transform.rotation = rotacaoInicial;
        cubo.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        timer.HideResults();

        if(controleAnimacoes.getContadorErros() == 3)
        {
            animInimigo.AnimaInimigo(0);
            coracoes.updateOpacityHearts(1);
            controleAnimacoes.setContadorErros(0);
            angulo.value = 0;
            massa.value = 1;
            atrito.value = 1;
            forca.value = 10;
    
            gameOver.SetTrigger("EscondeGameOver");
            cubo.GetComponent<MeshRenderer>().enabled = true;
            cuboAnimacao.GetComponent<Animator>().SetTrigger("Restart");
            cuboAnimacao.SetActive(false);
        }
        else if(controleAnimacoes.getAcertouQuestao())
        {
            controleAnimacoes.setAcertouQuestao(false);
            animInimigo.AnimaInimigo(-1);
            coracoes.updateOpacityHearts(1);
            controleAnimacoes.setContadorErros(0);
            angulo.value = 0;
            massa.value = 1;
            atrito.value = 1;
            forca.value = 10;

            //Trocar de questao (robo)
            if(questionPlano.indice < 3)
            {
                questionPlano.indice++;
                questionPlano.SetRobotDialog();
                controleAnimacoes.getRobotDialogue().ActivateBubbleOtherQuestion();
            }
            else
            {
                questionPlano.indice = 0;
                questionPlano.SetRobotDialog();
                controleAnimacoes.getRobotDialogue().ActivateBubbleOtherQuestion();
                controleQuestoes.AtualizaQuestaoAtiva(0);
            }
        }

        portal.SetTrigger("Fechar");
        cubo.GetComponent<MeshRenderer>().enabled = true;
    }
}
