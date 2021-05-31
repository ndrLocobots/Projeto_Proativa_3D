using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public GameObject menu;
    public Button botaoStart, botaoMenu, botaoRestore;

    void Start()
    {
        botaoStart.interactable = false;
        botaoMenu.interactable = false;
        botaoRestore.interactable = false;
    }

    public void Habilita()
    {
        if(!botaoStart.interactable)
            botaoStart.interactable = true;

        if(!botaoMenu.interactable)
            botaoMenu.interactable = true;

        if(!botaoRestore.interactable)
            botaoRestore.interactable = true;
    }

    public void ApertouOK()
    {
        if(menu.activeSelf)
            menu.SetActive(false);
    }
}
