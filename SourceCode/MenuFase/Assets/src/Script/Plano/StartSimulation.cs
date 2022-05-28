using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSimulation : MonoBehaviour
{
    public Rigidbody cubo;
    public GameObject portal;
    public GameObject menu;

    public Slider angulo;
    public Slider massa;
    public Slider atrito;
    public Slider forca;

    private Timer timer;
    private ControleAnimacoes controleAnim;

    private int anguloCorreto;
    private int atritoCorreto;
    private int massaCorreta;
    private float forcaCorreta;

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
        controleAnim.VerificaQuestao(massa.value, atrito.value, angulo.value, forca.value, anguloCorreto, atritoCorreto, massaCorreta, forcaCorreta);
        StartCoroutine(tempoAbrirPortal());
    }

    public void ApertouOK()
    {
        if(menu.activeSelf)
            menu.SetActive(false);
    }

    public void setRespostasCorretas(int anguloCorreto, int atritoCorreto, int massaCorreta, float forcaCorreta)
    {
        this.anguloCorreto = anguloCorreto;
        this.atritoCorreto = atritoCorreto;
        this.massaCorreta = massaCorreta;
        this.forcaCorreta = forcaCorreta;
    }

    IEnumerator tempoAbrirPortal()
    {
        yield return new WaitForSeconds(1.30f);
        portal.GetComponent<Animator>().SetTrigger("Abrir");
    }
}
