using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class GuiController : MonoBehaviour
{
    //Método utilizado pelos Botões da cena para indicar qual fase deve ser carregada.
    //public string sceneName;
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}