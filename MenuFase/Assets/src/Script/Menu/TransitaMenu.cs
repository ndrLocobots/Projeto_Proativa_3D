using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitaMenu : MonoBehaviour
{
    public void Carrega02()
    {

        string sceneName = "Menu02";
        UnloadAllScenesExcept(sceneName);
    }

    public void Carrega01()
    {

        string sceneName = "Menu01";
        UnloadAllScenesExcept(sceneName);
    }

    public void CarregaPlano()
    {
        string sceneName = "Plano";
        UnloadAllScenesExcept(sceneName);
    }

    public void CarregaMassa()
    {
        string sceneName = "Massa";
        UnloadAllScenesExcept(sceneName);
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
        Time.timeScale = 1;
    }

}