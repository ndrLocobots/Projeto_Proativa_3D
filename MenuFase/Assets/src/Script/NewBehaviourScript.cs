using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//Singleton<T> o T é uma espécie de template que será definido pelas outras classes/scripts que herdarem
//essa classe. Para entender melhor como usar esse T basta olhar a classe SceneController.
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    //Usado para armazenar a única instância que deve existir desse objeto no jogo.
    private static T instance;

    //Usado para coletar a instância dessa classe e conseguir utilizar os métodos.
    public static T getInstance()
    {
        if (instance == null)
            instance = (T)FindObjectOfType(typeof(T));

        return instance;
    }

    //Se for sobrescrever este método em alguma classe filha, lembrar de utilizar o comando base.SingletonStart();
    void Start()
    {
        SingletonStart();
    }

    //Usado para manter somente uma instância do objeto que utiliza essa classe. Caso seja carregada 
    //uma scene em que esse objeto já exista, o método irá destruir o objeto da scene e manter o mais antigo.
    public bool SingletonStart()
    {
        //Caso a variável instance já esteja preenchida e o gameobject for diferente do que está sendo executado, indica que esse é um novo objeto que deve ser destruído,
        //caso não esteja preenchido indica que é o primeiro objeto e ele deve ser mantido em todas as scenes.
        if (instance && !instance.gameObject.Equals(gameObject))
        {
            Destroy(gameObject);

            //Retorna falso indicando que esse objeto foi destruído e que as variáveis não devem ser inicializadas.
            return false;
        }
        else
        {
            //Usado para indicar que esse gameo bject não deve ser destruído ao fazer as transiçoes da tela.
            DontDestroyOnLoad(gameObject);


            //Caso a instance esteja preenchida não é preciso localizar ela novamente, isso pode acontecer caso algum script
            //chame a função getInstance antes do unity executar o start da classe que está herdando a Singleton. Isso pode acontecer
            //caso você utilize o valor de uma classe Singleton na função Start de uma outra classe. Caso você opte por utilizar algum método de uma classe singleton
            //dentro do Start de uma outra classe, você deve utilizar somente valores da classe singleton que você preencher via inspector.
            if (instance == null)
                //Usado para encontrar o objeto do tipo do template na scene. 
                //Deve existir somente um desse objeto na scene, e não será preciso existir ele em nenhuma scene posterior
                //pois esse objeto será mantido.
                instance = (T)FindObjectOfType(typeof(T));

            //Retorna verdadeiro indicando que esse objeto não foi destruído e que as variáveis devem ser inicializadas.
            return true;
        }
    }
}
