using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : MonoBehaviour
{
    private bool fuiAtingido, respostaCorreta;
    public Animator animAltar;
    public MeshRenderer cuboLan;

    void Start()
    {
        fuiAtingido = respostaCorreta = false;
    }
    void Update()
    {
        //Controle da animacao de quando o cubo atinge o altar
        if(fuiAtingido && respostaCorreta)
        {
            animAltar.SetBool("FuiAtingido", true);
            fuiAtingido = false;
            respostaCorreta = false;
        }
    }
    //Funcao para mudar o valor de "fuiAtingido" para verdadeiro
    public void setAtingido(bool valor)
    {
        this.fuiAtingido = valor;
    }
    //Muda o valor de "respostaCorreta" para ativar a animacao de sucesso
    public void setaRespostaCorreta(bool valor)
    {
        this.respostaCorreta = true;
    }
    //Ativa a animacao padrao do altar
    public void ativaIdle()
    {
        animAltar.SetBool("FuiAtingido", false);
    }
   
    public bool getFuiAtingido()
    {
        return this.fuiAtingido;
    }

    //Funcao que faz o cubo ficar invisivel ao final da animacao do altar desaparecendo (evento)
    public void escondeCubo()
    {
        cuboLan.enabled = false;   
    }
    //Funcao ue faz o cubo reaparecer quando a cena recomessa, ativado atraves da animacao IDLE do altar (evento)
    public void apareceCubo()
    {
        cuboLan.enabled = true;
    }
}
