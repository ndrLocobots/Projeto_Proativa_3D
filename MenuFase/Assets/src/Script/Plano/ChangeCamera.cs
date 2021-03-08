using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject camera01;
    public GameObject camera02;
    public GameObject camera03;
    public GameObject robo;

    private Vector3[] posicoesRobo;
    private Quaternion[] rotacoesRobo;

    void Start()
    {   
        //Inicial:  x = 6.267623 y = 9.52   z = -22.11263
        //Segunda:  x = 6.139    y = 9.52   z = -25.129
        //Terceira: x = 6.519951f y = 9.52f   z = -23.08969f
        posicoesRobo = new Vector3[3];
        posicoesRobo[0] = new Vector3(6.267623f, 9.52f, -22.11263f);
        posicoesRobo[1] = new Vector3(6.139f, 9.52f, -25.129f);
        posicoesRobo[2] = new Vector3(6.519951f, 9.52f, -23.08969f);

        //Inicial:  x = 0 y = 102.759f z = 0
        //Segunda:  x = 0 y = 3.1f     z = 0
        //Terceira: x = 0 y = 142.403f z = 0
        rotacoesRobo = new Quaternion[3];
        rotacoesRobo[0] = Quaternion.Euler(0, 102.759f, 0);
        rotacoesRobo[1] = Quaternion.Euler(0, 3.1f, 0);
        rotacoesRobo[2] = Quaternion.Euler(0, 142.403f, 0);
    }

    public void SelectCamera(float value)
    {
        if (value == 0)
        {
            camera01.SetActive(true);
            camera02.SetActive(false);
            camera03.SetActive(false);

            robo.transform.position = posicoesRobo[0];
            robo.transform.rotation = rotacoesRobo[0];
        }
        if (value == 1)
        {
            camera01.SetActive(false);
            camera02.SetActive(true);
            camera03.SetActive(false);

            robo.transform.position = posicoesRobo[1];
            robo.transform.rotation = rotacoesRobo[1];
        }
        if (value == 2)
        {
            camera01.SetActive(false);
            camera02.SetActive(false);
            camera03.SetActive(true);

            robo.transform.position = posicoesRobo[2];
            robo.transform.rotation = rotacoesRobo[2];
        }
    }
}
