using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartEMenu : MonoBehaviour
{
    private bool primeiroExercicio;

    public Button botaoStart, botaoMenu, botaoVoltar;
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

    public void voltarAoMenuInicial()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
