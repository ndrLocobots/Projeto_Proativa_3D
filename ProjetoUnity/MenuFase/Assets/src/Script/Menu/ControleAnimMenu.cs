using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleAnimMenu : MonoBehaviour
{
    public Animator animatorJogar;
    public Animator animatorAjuda;
    public Animator animatorSair;
    public Animator animadorVoltar;

    public Animator animadorLanca;
    public Animator animadorQueda;
    public Animator animadorPlano;

    public Animator telaInicial;
    public Animator telaSim;

    void Start()
    {
        telaInicial.SetBool("Ativa", true);
        telaSim.SetBool("Ativo", false);
    }

    public void ativaMouseEmCima_Jogar()
    {
        animatorJogar.SetBool("MouseUp", true);
    }

    public void desativaMouseEmCima_Jogar()
    {
        animatorJogar.SetBool("MouseUp", false);
    }

    public void ativaMouseEmCima_Ajuda()
    {
        animatorAjuda.SetBool("MouseUp", true);
    }

    public void desativaMouseEmCima_Ajuda()
    {
        animatorAjuda.SetBool("MouseUp", false);
    }

    public void ativaMouseEmCima_Sair()
    {
        animatorSair.SetBool("MouseUp", true);
    }

    public void desativaMouseEmCima_Sair()
    {
        animatorSair.SetBool("MouseUp", false);
    }

    public void ativaMouseEmCima_Voltar()
    {
        animadorVoltar.SetBool("MouseUp", true);
    }

    public void desativaMouseEmCima_Voltar()
    {
        animadorVoltar.SetBool("MouseUp", false);
    }

    public void ativaMouse_Plano()
    {
        animadorPlano.SetBool("MouseUp", true);
    }

    public void ativaMouse_Queda()
    {
        animadorQueda.SetBool("MouseUp", true);
    }

    public void ativaMouse_Lanca()
    {
        animadorLanca.SetBool("MouseUp", true);
    }

    public void desativaMouse_Plano()
    {
        animadorPlano.SetBool("MouseUp", false);
    }

    public void desativaMouse_Queda()
    {
        animadorQueda.SetBool("MouseUp", false);
    }

    public void desativaMouse_Lanca()
    {
        animadorLanca.SetBool("MouseUp", false);
    }

    public void recolheTelaInicial()
    {
        telaInicial.SetBool("Ativa", false);
    }

    public void chamaTelaInicial()
    {
        telaInicial.SetBool("Ativa", true);
    }

    public void chamaTelaSim()
    {
        telaSim.SetBool("Ativo", true);
    }

    public void recolheTelaSim()
    {
        telaSim.SetBool("Ativo", false);
    }
}
