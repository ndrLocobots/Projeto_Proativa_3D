using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleBotoes : MonoBehaviour
{
    public GameObject menu;

    void Start() {}

    void Update() {}

    public void AbreMenu()
    {
        menu.SetActive(true);
    }

    public void FechaMenu()
    {
        menu.SetActive(false);
    }
}
