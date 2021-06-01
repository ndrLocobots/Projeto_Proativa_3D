using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleAnimacoes : MonoBehaviour
{
    public GameObject cubo;
    public GameObject cuboParaAnimacao;
    public Animator portal;
    public Animator panel_victory, panel_lose;
    public Button botaoStart;
    public Button botaoRestore;
    public Button botaoMenu;

    public SoundsAnimationP sound;

    [SerializeField]
    private Restart restart;

    private robotAnimation animRobo;
    private AnimInimigo animInimigo;
    private heart coracoes;
    private bool acertouQuestao, podeRodarAnimFinal;
    private QuestionPlano questionPlano;
    private dialog robotDialogue;
    private ControleQuestoes controleQuestoes;

    private float tempoInicio;
    private bool estaResolvendo;

    private int contadorErros;

    void OnTriggerEnter()
    {
        if(contadorErros == 1 && !acertouQuestao)
        {
            AnimErro(1);
        }
        else if(contadorErros == 2 && !acertouQuestao)
        {
            AnimErro(2);
        }
        else if(contadorErros == 3 && !acertouQuestao)
        {
            podeRodarAnimFinal = true;
            AnimErro(3);
        }
            
    }

    void Start()
    {
        animRobo = FindObjectOfType<robotAnimation>();
        questionPlano = FindObjectOfType<QuestionPlano>();
        coracoes = FindObjectOfType<heart>();
        animInimigo = FindObjectOfType<AnimInimigo>();
        robotDialogue = FindObjectOfType<dialog>();
        controleQuestoes = FindObjectOfType<ControleQuestoes>();
        controleQuestoes.AtualizaQuestaoAtiva(0);

        contadorErros = 0;
        acertouQuestao = false;
        podeRodarAnimFinal = false;
        estaResolvendo = false;
        panel_victory.SetBool("action", false);
        panel_lose.SetBool("action", false);
    }

    void Update()
    {
        if(estaResolvendo && !robotDialogue.isTalk)
        {
            if(Time.time - tempoInicio >= 25)
            {
                robotDialogue.ActivateBubbleReminder();
                robotDialogue.TalkWithBubble();
                tempoInicio = Time.time;
                estaResolvendo = false;
            }
        }
    }

    public void VerificaQuestao(float valorMassa, float valorAtrito, float valorAngulo, float valorForca, int anguloCorreto, int atritoCorreto, int massaCorreta, float forcaCorreta)
    {
        if(questionPlano.indice == 0)
        {
            if(valorAtrito == atritoCorreto && valorAngulo == anguloCorreto)
            {
                AnimAcerto(1);
            }
            else
            {
                contadorErros++;
            }
        }
        else if(questionPlano.indice == 1)
        {
            if(valorMassa == massaCorreta && valorAngulo == anguloCorreto && (valorForca >= (forcaCorreta - 0.3f) && valorForca <= (forcaCorreta + 0.3f)))
            {
                AnimAcerto(2);
            }
            else
            {
                contadorErros++;
            }
        }
        else if(questionPlano.indice == 2)
        {
            if (valorAngulo == anguloCorreto && valorMassa == massaCorreta && (valorForca >= (forcaCorreta - 0.3f)) && (valorForca <= (forcaCorreta + 0.3f)))
            {
                AnimAcerto(3);
            }
            else
            {
                contadorErros++;
            }
        }


        
    }

    public void AnimAcerto(int i)
    {
        acertouQuestao = true;
        animRobo.RobotHappy();
        robotDialogue.SetHappyBubble();
        robotDialogue.TalkWithBubble();
        animInimigo.AnimaInimigo(0);
        portal.SetTrigger("Sucesso"); 
        controleQuestoes.AtualizaQuestaoAtiva(i);
        controleQuestoes.setConcluidas(1, i - 1);
        sound.PlayPortal();

        if (i == 3)
            panel_victory.SetBool("action", true);

        StartCoroutine(RestauraCenaPosAcerto());
    }

    IEnumerator RestauraCenaPosAcerto()
    {
        botaoMenu.interactable = false;
        botaoRestore.interactable = false;
        botaoStart.interactable = false;

        yield return new WaitForSeconds(10);

        botaoMenu.interactable = true;
        botaoRestore.interactable = true;
        botaoStart.interactable = true;

        restart.RestartScene();
    }

    public void AnimErro(int tentativa)
    {
        robotDialogue.SetSadBubble();
        robotDialogue.TalkWithBubble();
        sound.PlayEnemy();

        if(tentativa == 1)
        {
            coracoes.loseHeart();
            animRobo.RobotSad();
            animInimigo.AnimaInimigo(1);
        }
        else if(tentativa == 2)
        {
            coracoes.loseHeart();
            animRobo.RobotSad();
            animInimigo.AnimaInimigo(2);
        }
        else if(tentativa == 3 && podeRodarAnimFinal)
        {
            coracoes.loseHeart();
            animRobo.RobotSad();
            animInimigo.AnimaInimigo(3);
            podeRodarAnimFinal = false;
            
        }
    }

    public void AtivaRobosCarregandoCubo()
    {
        animInimigo.AnimaInimigo(4);
        panel_lose.SetBool("action", true);
    }

    public void AtivaCuboSendoCarregado()
    {
        cubo.GetComponent<MeshRenderer>().enabled = false;
        cuboParaAnimacao.SetActive(true);
        cuboParaAnimacao.GetComponent<Animator>().SetTrigger("Perdemo");
    }


    public int getContadorErros()
    {
        return this.contadorErros;
    }

    public void setContadorErros(int valor)
    {
        this.contadorErros = valor;
    }

    public bool getAcertouQuestao()
    {
        return this.acertouQuestao;
    }

    public void setAcertouQuestao(bool valor)
    {
        this.acertouQuestao = valor;
    }

    public dialog getRobotDialogue()
    {
        return this.robotDialogue;
    }

    public void setEstResolvendo(bool valor)
    {
        this.estaResolvendo = valor;
    }

    public void setTempoInicio()
    {
        this.tempoInicio = Time.time;
    }
}