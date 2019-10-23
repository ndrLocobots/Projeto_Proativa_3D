using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitaMenu : MonoBehaviour
{
    public void Carrega02()
    {
        SceneManager.LoadScene("Menu02");
    }

    public void Carrega01()
    {
        SceneManager.LoadScene("Menu01");
    }

    public void CarregaPlano()
    {
        SceneManager.LoadScene("Plano");
    }

    public void CarregaMassa()
    {
        SceneManager.LoadScene("Massa");
    }

    public void CarregaQueda()
    {
        SceneManager.LoadScene("Queda");
    }

    public void CarregaForca()
    {
        SceneManager.LoadScene("Forca");
    }

    public void CarregaLanc()
    {
        SceneManager.LoadScene("Lancamento");
    }

    public void Sair()
    {
        Application.Quit();
    }
}
