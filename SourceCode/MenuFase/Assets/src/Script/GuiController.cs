using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class GuiController : MonoBehaviour
{
    
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void GoToEnd()
    {
        Application.Quit();
    }
}
