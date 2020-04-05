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
        string sceneName = "Plano";
        UnloadAllScenesExcept(sceneName);
        SceneManager.LoadSceneAsync("Plano");
    }

    public void CarregaMassa()
    {
        string sceneName = "Massa";
        UnloadAllScenesExcept(sceneName);
        SceneManager.LoadSceneAsync("Massa");
    }

    public void CarregaQueda()
    {
        string sceneName = "Queda";
        UnloadAllScenesExcept(sceneName);
    }

    public void CarregaForca()
    {
        string sceneName = "Forca";
        UnloadAllScenesExcept(sceneName);
    }

    public void CarregaLanc()
    {
        string sceneName = "Lancamento";
        UnloadAllScenesExcept(sceneName);
    }

    public void Sair()
    {
        Application.Quit();
    }

    void UnloadAllScenesExcept(string sceneName)
    {
        int c = SceneManager.sceneCount;
        for (int i = 0; i < c; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            print(scene.name);
            SceneManager.UnloadSceneAsync(scene);
            
        }
        SceneManager.LoadSceneAsync(sceneName);
    }
}
