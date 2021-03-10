using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerAnim : MonoBehaviour
{
    private ControleAnimacoes controleAnimacoes;

    public Button botaoMenu, botaoStart, botaoRestart;
    public MeshRenderer cubo;
    public Animator gameOver;

    void Start()
    {
        controleAnimacoes = FindObjectOfType<ControleAnimacoes>();
    }

    public void ChamaAnimCubo()
    {
        controleAnimacoes.AtivaCuboSendoCarregado();
    }

    public void ChamaAnimRobos()
    {
        controleAnimacoes.AtivaRobosCarregandoCubo();
    }

    public void DesabilitaBotoes()
    {
        botaoMenu.interactable = false;
        botaoStart.interactable = false;
        botaoRestart.interactable = false;
    }

    public void ReabilitaBotoes()
    {
        botaoMenu.interactable = true;
        botaoStart.interactable = true;
        botaoRestart.interactable = true;
    }

    public void DesabilitaCubo()
    {
        cubo.enabled = false;
    }

    public void MostraGameOver()
    {
        gameOver.SetTrigger("MostraGameOver");
    }
}
