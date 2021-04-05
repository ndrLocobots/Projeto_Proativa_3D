using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleBotoes : MonoBehaviour
{
    public GameObject menu;
    public GameObject botoesFases;
    public Button start;
    public Button menuBotao;

    void Start()
    {
        menuBotao.interactable = false;
        start.interactable = false;
    }

    void Update() {}

    public void HabilitaBotoes()
    {
        if(!botoesFases.activeSelf)
            botoesFases.SetActive(true);
    }

    public void AbreMenu()
    {
        if(!menu.activeSelf)
            menu.SetActive(true);
        else
            FechaMenu();
    }

    public void FechaMenu()
    {
        menu.SetActive(false);
    }
}
