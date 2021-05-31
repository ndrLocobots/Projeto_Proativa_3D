using UnityEngine;
using System.Collections;
public class GuiController : MonoBehaviour
{
    //Método utilizado pelos Botões da cena para indicar qual fase deve ser carregada.
    public void GoToScene(string sceneName)
    {
        //Utiliza o método da classe SceneController para carregar a nova scene.
        //Note que estamos acessando a classe de uma forma stática, isso ocorre por conta da herança com a classe Singleton.
        SceneController.getInstance().LoadScene(sceneName);
    }
}