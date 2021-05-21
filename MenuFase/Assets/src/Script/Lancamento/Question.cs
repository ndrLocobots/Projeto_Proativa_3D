using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Linq;
public class Question : MonoBehaviour
{
  public float distaceDelta;

  private float velocityX, velocityY, velocity;
  private float time, maxHeight, angle;

  public int level;
  public Text respostas;

  private CSVfile csvfile;

  [SerializeField]
  private ScreenResults screenResults;

  void Awake()
  {
    csvfile = gameObject.AddComponent<CSVfile>();
    level = 0;

    SetRobotDialog();
  }

  public void SetRobotDialog()
  {
    MakeDataQuestion();

    dialog robotDialog = FindObjectOfType<dialog>();

    if (robotDialog)
    {
      robotDialog.setences = GetDialog();
      level += 1;
    }
  }

  void MakeDataQuestion()
  {
    distaceDelta = 0;
    while (distaceDelta < 30 || distaceDelta > 250)
    {
      angle = (int)Random.Range(1, 90f);
      float RadianAngle = angle * Mathf.PI / 180;
      velocity = (int)Random.Range(1, 50f);

      velocityY = velocity * Mathf.Sin(RadianAngle);
      velocityX = velocity * Mathf.Cos(RadianAngle);

      time = velocityY / 5;

      maxHeight = velocityY * time / 2;

      distaceDelta = velocityX * time;
    }
    Debug.Log("Angulo: " + angle + " Velocidade: " + velocity);
    respostas.text = "Angulo: " + angle + " Velocidade: " + velocity;
    screenResults.velocidadeC = velocity;
    screenResults.anguloC = angle;
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

    if (level >= 3)
    {
      level = 3;
    }

    string question = allquestion[level];

    return question.Replace("{t}", time.ToString("0.00"))
    .Replace("{dx}", distaceDelta.ToString("0.00"))
    .Replace("{vx}", velocityX.ToString("0.00"))
    .Replace("{vy}", velocityY.ToString("0.00"))
    .Replace("{mh}", maxHeight.ToString("0.00"))
    .Replace("{th}", (time / 2).ToString("0.00"))
    .Replace("{a}", (angle).ToString("0.00"))
    ;
  }

  public string GetQuestion(int index)
  {
    List<string> allquestion = csvfile.ReadCSVFile("lancamento_exemple");
    string question = allquestion[index];

    return question.Replace("{t}", time.ToString("0.00"))
    .Replace("{dx}", distaceDelta.ToString("0.00"))
    .Replace("{vx}", velocityX.ToString("0.00"))
    .Replace("{vy}", velocityY.ToString("0.00"))
    .Replace("{mh}", maxHeight.ToString("0.00"))
    .Replace("{th}", (time / 2).ToString("0.00"))
    .Replace("{a}", (angle).ToString("0.00"))
    ;
  }

  public string ReturnAnswer()
  {
    return "V = " + velocity.ToString("0.00") + "\n" +
    "A = " + angle.ToString("0.00");
  }
}
