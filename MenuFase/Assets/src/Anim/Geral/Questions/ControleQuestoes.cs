using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleQuestoes : MonoBehaviour
{
    public Animator questao1, questao2, questao3, infoQuestoes;
    public Text titulo, enunciado, dadosInformados, dadosEsperados, pontuacao;

    private QuestionPlano questionPlano;

    void Start()
    {
        questionPlano = FindObjectOfType<QuestionPlano>();
    }

    public void AtualizaQuestaoAtiva(int indice)
    {
        if(indice == 0)
        {
            questao1.SetBool("Ativo", true);
            questao1.SetBool("Padrao", false);
            questao1.SetBool("Concluido", false);

            questao2.SetBool("Ativo", false);
            questao2.SetBool("Padrao", true);
            questao2.SetBool("Concluido", false);

            questao3.SetBool("Ativo", false);
            questao3.SetBool("Padrao", true);
            questao3.SetBool("Concluido", false);
        }
        else if(indice == 1)
        {
            questao1.SetBool("Ativo", false);
            questao1.SetBool("Padrao", false);
            questao1.SetBool("Concluido", true);

            questao2.SetBool("Ativo", true);
            questao2.SetBool("Padrao", false);
            questao2.SetBool("Concluido", false);

            questao3.SetBool("Ativo", false);
            questao3.SetBool("Padrao", true);
            questao3.SetBool("Concluido", false);
        }
        else if(indice == 2)
        {
            questao1.SetBool("Ativo", false);
            questao1.SetBool("Padrao", false);
            questao1.SetBool("Concluido", true);

            questao2.SetBool("Ativo", false);
            questao2.SetBool("Padrao", false);
            questao2.SetBool("Concluido", true);

            questao3.SetBool("Ativo", true);
            questao3.SetBool("Padrao", false);
            questao3.SetBool("Concluido", false);
        }
        else if(indice == 3)
        {
            questao1.SetBool("Ativo", false);
            questao1.SetBool("Padrao", false);
            questao1.SetBool("Concluido", true);

            questao2.SetBool("Ativo", false);
            questao2.SetBool("Padrao", false);
            questao2.SetBool("Concluido", true);

            questao3.SetBool("Ativo", false);
            questao3.SetBool("Padrao", false);
            questao3.SetBool("Concluido", true);
        }
    }

    public void MostraDadosQ1()
    {
        if(!infoQuestoes.GetBool("Mostrar"))
        {
            if(questionPlano.indice > 0)
            {
                titulo.text = "Questão: 1";
                enunciado.text = "Enunciado: ";
                enunciado.text += questionPlano.GetQuestion(0);
                dadosInformados.text = "Dados informados por você: NaN";
                dadosEsperados.text = "Dados esperados pelo LocoBits: NaN";
                pontuacao.text = "Sua pontuação: NaN";

                infoQuestoes.SetBool("Mostrar", true);
            }
        }
        else
        {
            EscondeDados();
        }   
    }

    public void MostraDadosQ2()
    {
        if(!infoQuestoes.GetBool("Mostrar"))
        {
            if(questionPlano.indice > 1)
            {
                titulo.text = "Questão: 2";
                enunciado.text = "Enunciado: ";
                enunciado.text += questionPlano.GetQuestion(1);
                dadosInformados.text = "Dados informados por você: NaN";
                dadosEsperados.text = "Dados esperados pelo LocoBits: NaN";
                pontuacao.text = "Sua pontuação: NaN";

                infoQuestoes.SetBool("Mostrar", true);
            }
        }
        else
        {
            EscondeDados();
        } 
    }

    public void MostraDadosQ3()
    {
        if(!infoQuestoes.GetBool("Mostrar"))
        {
            infoQuestoes.SetBool("Mostrar", true);
        }
        else
        {
            EscondeDados();
        } 
    }

    public void EscondeDados()
    {
        infoQuestoes.SetBool("Mostrar", false);
    }
}
