using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maos : MonoBehaviour
{
    private SelecionaMao[] seleciona;

    void Start()
    {
        seleciona = FindObjectsOfType<SelecionaMao>();
    }

    public void Destro()
    {
        seleciona[0].SetMaoDireita();
    }

    public void Canhoto()
    {
        seleciona[0].SetMaoEsquerda();
    }
}
