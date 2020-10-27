using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;
public class Question : MonoBehaviour
{
  public float distaceDelta;
  float velocityX, velocityY, time, maxHeight, velocity, angle;

  CSVfile csvfile;
  
  void Awake()
  {
    csvfile = gameObject.AddComponent<CSVfile>();
    SetRobotDialog();
  }

  public void SetRobotDialog()
  {
    MakeDataQuestion();
    
    dialog robotDialog = FindObjectOfType<dialog>();

    if (robotDialog)
    {
      robotDialog.setences = GetDialog();
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

  string[] GetDialog()
  {    
    List<string> setencas = new List<string>();
    setencas = csvfile.ReadCSVFile("lancamento_vertical_dialog");

    setencas.Add(GetExample());

    return setencas.ToArray();
  }

  string GetExample()
  {
    
    List<string> allquestion = csvfile.ReadCSVFile("lancamento_exemple");
    int indice = Random.Range(0, allquestion.Count - 1);

    string question = allquestion[indice];

    return question.Replace("{t}", time.ToString("0.00"))
    .Replace("{dx}", distaceDelta.ToString("0.00"))
    .Replace("{vx}", velocityX.ToString("0.00"))
    .Replace("{vy}", velocityY.ToString("0.00"))
    .Replace("{mh}", maxHeight.ToString("0.00"));
  }
}
