using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public GameObject cubo;
    public Animator portal;

    private Vector3 posicaoInicial;
    private Quaternion rotacaoInicial;
    private Timer timer;

    void Start()
    {
        timer = FindObjectOfType<Timer>();
    }

    public void SetPosInicial(Vector3 posCubo, Quaternion rotCubo)
    {
        posicaoInicial = posCubo;
        rotacaoInicial = rotCubo;
    }

    public void RestartScene()
    {
        cubo.transform.position = posicaoInicial;
        cubo.transform.rotation = rotacaoInicial;
        cubo.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        timer.HideResults();

        portal.SetTrigger("Fechar");
    }
}
