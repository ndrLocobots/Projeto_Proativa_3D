using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSimulation : MonoBehaviour
{
    public Rigidbody cubo;
    public GameObject portal;

    public Slider angulo;
    public Slider massa;
    public Slider atrito;

    private Timer timer;
    private ControleAnimacoes controleAnim;

    public void Start()
    {
        controleAnim = FindObjectOfType<ControleAnimacoes>();

        cubo.constraints = RigidbodyConstraints.FreezeAll;

        timer = FindObjectOfType<Timer>();
    }
    
    public void StartSim()
    {
        cubo.constraints = ~RigidbodyConstraints.FreezeAll;
        timer.SetBotaoApertado(true);
        controleAnim.VerificaQuestao(massa.value, atrito.value, angulo.value);
        StartCoroutine(tempoAbrirPortal());
    }

    IEnumerator tempoAbrirPortal()
    {
        yield return new WaitForSeconds(1.30f);
        portal.GetComponent<Animator>().SetTrigger("Abrir");
    }
}
