using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartEMenu : MonoBehaviour
{
    private bool primeiroExercicio;

    public Button botaoStart, botaoMenu;
    public GameObject confirmacao;
    
    void Start()
    {
        primeiroExercicio = true;
        botaoStart.interactable = false;
        botaoMenu.interactable = false;
    }

    public void ExibeConfirmacao()
    {
        if(primeiroExercicio)
        {
            confirmacao.SetActive(true);
            primeiroExercicio = false;
        }
    }

    public void FinalizaConfirmacao()
    {
        confirmacao.SetActive(false);
    }

    public bool getPrimeiroExercicio()
    {
        return this.primeiroExercicio;
    }
}
