using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{
  public float distaceDelta;
  float velocityX, velocityY, time, maxHeight, velocity, angle;

  public string[] setencas;

  void Start()
  {
    UpadateRobotSetence();
  }

  public void UpadateRobotSetence()
  {
    MakeDataQuestion();

    dialog robotDialog = FindObjectOfType<dialog>();

    if (robotDialog)
    {
      robotDialog.setences = GetSetences();
    }
  }

  void MakeDataQuestion()
  {
    distaceDelta = 0;
    while (distaceDelta<30 || distaceDelta>250)
    {
      angle = Random.Range(1, 90f);
      float RadianAngle = angle * Mathf.PI / 180;
      velocity = Random.Range(1, 50f);

      velocityY = velocity * Mathf.Sin(RadianAngle);
      velocityX = velocity * Mathf.Cos(RadianAngle);

      time = velocityY / 5;

      maxHeight = velocityY * time / 2;

      distaceDelta = velocityX * time;
    }
    Debug.Log("Angulo: " + angle + " Velocidade: " + velocity);
  }

  string[] GetSetences()
  {
    setencas = new string[7];

    setencas[0] = "Olá gamer, meu nome é locobits !! Estou muito feliz de ter você aqui comigo. Seja bem vindo ao simulador de universos da Locobots.";

    setencas[1] = "Você escolheu a simulação de lançamento vertical. Graças às atualizações em  nossos sistema, esse mundo não possui atrito no ar, e sua gravidade é de 10 m/s², um ótimo mundo  para se fazer experimento, Dê uma explorada em nossa linda paisagem ";

    setencas[2] = "(Colocar teoria do lançamento vertical, curiosidades)";

    setencas[3] = "Agora que você já aprendeu como funciona o lançamento vertical, vamos testar o seu conhecimento! Seu objetivo nessa fase é chegar até o nosso teletransportador, Essa máquina brilhante aqui do meu lado.";

    setencas[4] = "Ops, parece que seu teletransportador mudou de posição";

    setencas[5] = "Cuidado! Meus sensores indicam a aproximação de inimigos. Você terá três tentativas.";

    setencas[6] = returnQuestion();

    return setencas;
  }

  string returnQuestion()
  {
    int tam = 3;

    string[] question = new string[tam];
    int index = Random.Range(0, tam);

    question[0] = "De acordo com meu relatório, o centro do teletransportador está a uma distância e tempo de " + distaceDelta.ToString("0.00") + " metros e " + time.ToString("0.00") + " segundos de você";

    question[1] = "De acordo com meu relatório, você atingirá a altura máxima, " + maxHeight.ToString("0.00") + " metros, em " + (time / 2).ToString("0.00") + " segudos.";

    question[2] = "De acordo com meu relatório, o ângulo necessário para atingir o teletransportador é de " + angle.ToString() + "graus e a velocidade horizontal de " + velocityX.ToString() + "metros";

    return question[index];
  }
}
