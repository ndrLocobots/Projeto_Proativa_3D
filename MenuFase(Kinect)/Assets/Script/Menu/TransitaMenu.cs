using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitaMenu : MonoBehaviour
{
    private SelecionaMao[] seleciona;
    public KinectManager[] kinectManagers;
    
    public GameObject botaoMaoEsq, botaoMaoDir, escolher, sair;

    void Start()
    {
        seleciona = FindObjectsOfType<SelecionaMao>();
        kinectManagers = FindObjectsOfType<KinectManager>();

        StartCoroutine(FakeCalibrated());
    }

    IEnumerator FakeCalibrated()
    {
        yield return new WaitForSeconds(0.1f);
        kinectManagers[0].ClearKinectUsers();
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Menu01")
        {
            if(seleciona[0].GetMaoDireita() || seleciona[0].GetMaoEsquerda())
            {
                botaoMaoDir.SetActive(false);
                botaoMaoEsq.SetActive(false);
                escolher.SetActive(true);
                sair.SetActive(true);
            }
        }
    }

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
        FakeCalibrated();
        string sceneName = "Plano";
        UnloadAllScenesExcept(sceneName);
    }

    public void CarregaMassa()
    {
        FakeCalibrated();
        string sceneName = "Massa";
        UnloadAllScenesExcept(sceneName);
    }

    public void CarregaQueda()
    {
        FakeCalibrated();
        string sceneName = "Queda";
        UnloadAllScenesExcept(sceneName);
    }

    public void CarregaForca()
    {
        FakeCalibrated();
        string sceneName = "Forca";
        UnloadAllScenesExcept(sceneName);
    }

    public void CarregaLanc()
    {
        FakeCalibrated();
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
