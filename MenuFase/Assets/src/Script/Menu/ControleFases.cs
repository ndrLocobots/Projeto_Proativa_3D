using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControleFases : MonoBehaviour
{
    public bool fezTutorial;

    public Button botaoPlano, botaoQueda;

    void Awake()
    {
        fezTutorial = FindObjectOfType<ControleTutorial>().fezTutorial;
        AtualizaBotoesDasFases();
    }

    public void AtualizaBotoesDasFases()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            if(fezTutorial)
            {
                if(!botaoPlano.IsInteractable() && !botaoQueda.IsInteractable())
                {
                    botaoPlano.interactable = true;
                    botaoQueda.interactable = true;
                }
            }
            else if(!fezTutorial)
            {
                botaoPlano.interactable = false;
                botaoQueda.interactable = false;
            }
        }
    }
}
