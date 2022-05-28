using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarCena : MonoBehaviour
{ 
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);   
    }
}
