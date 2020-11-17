using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoStart : MonoBehaviour
{
    private bool primeiroExercicio;
    private Button botaoStart;

    public GameObject confirm;

    void Start()
    {
        primeiroExercicio = true;
        botaoStart = GetComponent<Button>();
        botaoStart.interactable = false;
    }

    public void exibeConfirmacao()
    {
        if(primeiroExercicio)
        {
            confirm.SetActive(true);
            primeiroExercicio = false;
        }
    }

    public void finalizaConfirmacao()
    {
        confirm.SetActive(false);
    }

    public bool getPrimeiroExercicio()
    {
        return this.primeiroExercicio;
    }
}
