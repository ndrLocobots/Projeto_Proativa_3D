using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesabilitaLancamento : MonoBehaviour
{
    public TransitaMenu transita;
    public GameObject lancamento, fakelanca;
    public KinectManager manager;

    private float curX, curY, initX, initY;
    private bool foundManager;

    void Start()
    {
        manager = FindObjectOfType<KinectManager>();
        lancamento.SetActive(false);
        foundManager = true;

        initX = manager.HandCursor1.transform.position.x;
        initY = manager.HandCursor1.transform.position.x;
    }

    void Update()
    {
        if(foundManager)
        {
            curX = manager.HandCursor1.transform.position.x;
            curY = manager.HandCursor1.transform.position.y;
        }

        //Fazer a difernça entre os dois e estabelecer um valor minimo para considerar movimento;
        if(Mathf.Abs(curX - initX) > 0.14f || Mathf.Abs(curY - initY) > 0.14f)
            if(!lancamento.active)
            {
                lancamento.SetActive(true);
                fakelanca.SetActive(false);
            }
    }
}
