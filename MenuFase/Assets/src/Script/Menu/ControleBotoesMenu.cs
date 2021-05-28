using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleBotoesMenu : MonoBehaviour
{
    public void CarregaLancamento()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void CarregaPlano()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void CarregaQueda()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void SaiDoJogo()
    {
        Application.Quit();
    }
}
