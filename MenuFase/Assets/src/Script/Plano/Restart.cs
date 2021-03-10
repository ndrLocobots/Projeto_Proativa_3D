using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public GameObject cubo;
    public GameObject cuboAnimacao;
    public Animator portal, gameOver;

    private Vector3 posicaoInicial;
    private Quaternion rotacaoInicial;
    private Timer timer;
    private AnimInimigo animInimigo;
    private ControleAnimacoes controleAnimacoes;
    private heart coracoes;
    private QuestionPlano questionPlano;

    void Start()
    {
        timer = FindObjectOfType<Timer>();
        animInimigo = FindObjectOfType<AnimInimigo>();
        controleAnimacoes = FindObjectOfType<ControleAnimacoes>();
        questionPlano = FindObjectOfType<QuestionPlano>();
        coracoes = FindObjectOfType<heart>();
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

            //Trocar de questao (robo)
            questionPlano.SetRobotDialog();
        }

        portal.SetTrigger("Fechar");
        cubo.GetComponent<MeshRenderer>().enabled = true;
    }
}
