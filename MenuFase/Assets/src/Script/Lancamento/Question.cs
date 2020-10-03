using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{
  public float distaceDelta;
  float velocityX, velocityY, time, maxHeight, velocity, angle;

  CSVfile csvfile = new CSVfile();
  
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
    while (distaceDelta < 30 || distaceDelta > 250)
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
    List<string> setencas = new List<string>();

    string path = "./Text/lancamento_vertical_dialog.csv";
    setencas = csvfile.ReadCSVFile(path);
    setencas.Add(returnQuestion());

    return setencas.ToArray();
  }

  string returnQuestion()
  {

    string path = "./Text/lancamento_exemple.csv";
    List<string> allquestion = csvfile.ReadCSVFile(path);
    int indice = Random.Range(0, allquestion.Count - 1);

    string question = allquestion[indice];

    return question.Replace("{t}", time.ToString("0.00"))
    .Replace("{dx}", distaceDelta.ToString("0.00"))
    .Replace("{vx}", velocityX.ToString("0.00"))
    .Replace("{vy}", velocityY.ToString("0.00"))
    .Replace("{mh}", maxHeight.ToString("0.00"));
  }
}
