using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleSom : MonoBehaviour
{
    public GameObject comSom;
    public GameObject semSom;
    // Start is called before the first frame update
    void Start()
    {
        comSom.SetActive(true);
        semSom.SetActive(false);
    }

    // Update is called once per frame
    public void AtivaSom()
    {
        AudioListener.volume = 1f;
        comSom.SetActive(true);
        semSom.SetActive(false);
    }

    public void DesativaSom()
    {
        AudioListener.volume = 0f;
        comSom.SetActive(false);
        semSom.SetActive(true);
    }
}
