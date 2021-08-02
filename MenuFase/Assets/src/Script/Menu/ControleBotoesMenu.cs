using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleBotoesMenu : MonoBehaviour
{
    public GameObject help;
    public GameObject help2;
    public GameObject help3;

    private bool flag;

    private void Start()
    {
        flag = true;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))

            if (flag)
            {
                AudioListener.volume = 0f;
                flag = !flag;
            }
            else
            {
                AudioListener.volume = 1f;
                flag = !flag;
            }
    }

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

    public void MostraHelp()
    {
        if (!help.activeSelf)
        {
            EscondeHelp2();
            EscondeHelp3();
            help.SetActive(true);
        }
        else
            EscondeHelp();
    }

    public void MostraHelp2()
    {
        if (!help2.activeSelf)
        {
            EscondeHelp();
            EscondeHelp3();
            help2.SetActive(true);
        }
        else
            EscondeHelp2();
    }

    public void MostraHelp3()
    {
        if (!help3.activeSelf)
        {
            EscondeHelp(); 
            EscondeHelp2();
            help3.SetActive(true);
        }
        else
            EscondeHelp3();
    }

    public void EscondeHelp()
    {
        help.SetActive(false);
    }
    public void EscondeHelp2()
    {
        help2.SetActive(false);
    }
    public void EscondeHelp3()
    {
        help3.SetActive(false);
    }
}
