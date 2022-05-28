using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;
public class QuestionQueda : MonoBehaviour
{
  private float gravity, height, velocity;
  private float time;

  public int level;
  public GameObject sliderVelocidade;

  private CSVfile csvfile;

  [SerializeField]
  private CuboQue cubo;

  void Awake()
  {
    csvfile = gameObject.AddComponent<CSVfile>();
    velocity = 0;

    level = 0;
    SetRobotDialog();
  }

  public void SetRobotDialog()
  {
    NewMakeDataQuestion();

    dialog robotDialog = FindObjectOfType<dialog>();

    if (robotDialog)
    {
      robotDialog.setences = GetDialog();
      level += 1;
    }
  }

  // void MakeDataQuestion()
  // {
  //   float[] gravities = cubo.gravities;
  //   int index;

  //   height = (int)Random.Range(10, 50f);
  //   index = Random.Range(0, gravities.Length);
  //   gravity = gravities[index];

  //   time = Mathf.Sqrt(2 * height / gravity);
  //   velocity = Mathf.Sqrt(2 * gravity * height);

  //   if(level < 2)
  //   {
  //     sliderVelocidade.SetActive(false);
  //     Debug.Log("Altura: " + height + " Gravidade: " + gravity);
  //   }
  //   else
  //   {
  //     sliderVelocidade.SetActive(true);
  //     Debug.Log("Altura: " + height + " Gravidade: " + gravity + " Vloecidade: " + velocity);
  //   }
  // }

  void NewMakeDataQuestion()
  {
    float[] gravities = cubo.gravities;
    int index;

    if(level == 0)
    {
      index = Random.Range(0, gravities.Length);
      gravity = gravities[index];

      if (gravity == 3f)
        time = Random.Range(2.60f, 5.75f);
      else if (gravity == 10f)
        time = Random.Range(1.41f, 3.16f);
      else if (gravity == 20f)
        time = Random.Range(1f, 2.24f);

      height = (gravity * Mathf.Pow(time, 2)) / 2;
      height = Mathf.Round(height);

      Debug.Log("Altura: " + height + " Gravidade: " + gravity);
    }
    else if(level == 1)
    {
      index = Random.Range(0, gravities.Length);
      gravity = gravities[index];
      height = Random.Range(10f, 50f);
      height = Mathf.Round(height);
      time = Mathf.Sqrt((2 * height) / gravity);

      Debug.Log("Altura: " + height + " Gravidade: " + gravity);
    }
    else if(level == 2)
    {
      sliderVelocidade.SetActive(true);
      index = Random.Range(0, gravities.Length);
      gravity = gravities[index];

      if(gravity == 3f)
        velocity = Random.Range(7.8f, 17.2f);
      else if(gravity == 10f)
        velocity = Random.Range(14.1f, 31.6f);
      else if(gravity == 20f)
        velocity = Random.Range(20f, 44.7f);

      velocity = Mathf.Round(velocity);

      height = (Mathf.Pow(velocity, 2)) / (2 * gravity);
      height = Mathf.Round(height);

      Debug.Log("Altura: " + height + " Gravidade: " + gravity + " Vloecidad: " + velocity.ToString("0.00"));
    }
  }

  string[] GetDialog()
  {
    List<string> setencas = new List<string>();
    setencas = csvfile.ReadCSVFile("queda_dialog");

    string answer = GetExample();

    setencas.Add(answer);

    return setencas.ToArray();
  }

  string GetExample()
  {

    List<string> allquestion = csvfile.ReadCSVFile("queda_exemple");

    if (level >= allquestion.Count)
    {
      level = allquestion.Count - 1;
    }

    string question = allquestion[level];

    return question.Replace("{t}", time.ToString("0.00"))
    .Replace("{dy}", height.ToString("0.00"))
    .Replace("{g}", gravity.ToString("0.00"))
    //.Replace("{vy}", velocityY.ToString("0.00"))
    //.Replace("{mh}", maxHeight.ToString("0.00"))
    .Replace("{v}", velocity.ToString("0.00"))
    .Replace("{th}", time.ToString("0.00"))
    //.Replace("{a}", (angle).ToString("0.00"))
    ;
  }

  public string GetQuestion(int index)
  {
    List<string> allquestion = csvfile.ReadCSVFile("queda_exemple");
    return allquestion[index];
  }

  public float[] ReturnAnswer()
  {
    float[] resposta;
    float respostaDaGravidade;

    if(gravity == 20f)
      respostaDaGravidade = 0;
    else if(gravity == 10f)
      respostaDaGravidade = 1;
    else
      respostaDaGravidade = 2;

    if(velocity == 0)
    {
      resposta = new float[2] {height, respostaDaGravidade};
      return resposta;
    }
    else
    {
      resposta = new float[3] {height, respostaDaGravidade, velocity};
      velocity = 0;
      return resposta;
    }
  }
}
