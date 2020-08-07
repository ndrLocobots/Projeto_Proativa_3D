using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelecionaMao : MonoBehaviour
{
    public GameObject duasMaos;
    public GameObject maoDireita;
    public GameObject maoEsquerda;

    private bool destro, canhoto;

    void Start()
    {
        duasMaos.SetActive(true);
        maoDireita.SetActive(false);
        maoEsquerda.SetActive(false);

        destro = false;
        canhoto = false;
    }
    void Update()
    {
        if(destro)
        {
            duasMaos.SetActive(false);
            maoEsquerda.SetActive(false);
            maoDireita.SetActive(true);
        }
        else if(canhoto)
        {
            duasMaos.SetActive(false);
            maoDireita.SetActive(false);
            maoEsquerda.SetActive(true);
        }
    }

    public bool GetMaoEsquerda()
    {
        return this.canhoto;
    }

    public bool GetMaoDireita()
    {
        return this.destro;
    }

    public void SetMaoEsquerda()
    {
        this.canhoto = true;
    }

    public void SetMaoDireita()
    {
        this.destro = true;
    }

}
