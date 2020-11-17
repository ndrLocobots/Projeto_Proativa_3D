using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoMenu : MonoBehaviour
{
    private Button botaoMenu;

    void Start()
    {
        botaoMenu = GetComponent<Button>();
        botaoMenu.interactable = false;    
    }
}
