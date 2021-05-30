using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleFases : MonoBehaviour
{
    public bool fezTutorial, jaSetou;

    public Button botaoPlano, botaoQueda;

    void Start()
    {
        fezTutorial = false;
        jaSetou = false;
    }

    void Update()
    {
        if(fezTutorial && !jaSetou)
        {
            jaSetou = true;
            if(!botaoPlano.IsInteractable() && !botaoQueda.IsInteractable())
            {
                botaoPlano.interactable = true;
                botaoQueda.interactable = true;
            }
        }
        else if(!fezTutorial)
        {
            jaSetou = false;
            botaoPlano.interactable = false;
            botaoQueda.interactable = false;   
        }
    }
}
