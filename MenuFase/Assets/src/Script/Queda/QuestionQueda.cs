using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;
public class QuestionQueda : MonoBehaviour
{
  private float gravity, height;
  private float time;

  public int level;

  private CSVfile csvfile;

  [SerializeField]
  private CuboQue cubo;

  void Awake()
  {
    csvfile = gameObject.AddComponent<CSVfile>();
    cubo = FindObjectOfType<CuboQue>();
    
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
    float[] gravities = cubo.gravities;
    int index;

    height = (int)Random.Range(10, 50f);
    index = Random.Range(0, gravities.Length);
    gravity = gravities[index];

    time = Mathf.Sqrt(height / gravity);

    Debug.Log("Altura: " + height + "Gravidade:" + gravity);
  }

  string[] GetDialog()
  {
    List<string> setencas = new List<string>();
    setencas = csvfile.ReadCSVFile("queda_dialog");

    string answer = GetExample();
    answer = answer + "\nResposta: Altura: " + height + " Gravidade: " + gravity;

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
    //.Replace("{dx}", distaceDelta.ToString("0.00"))
    //.Replace("{vx}", velocityX.ToString("0.00"))
    //.Replace("{vy}", velocityY.ToString("0.00"))
    //.Replace("{mh}", maxHeight.ToString("0.00"))
    .Replace("{th}", (time / 2).ToString("0.00"))
    //.Replace("{a}", (angle).ToString("0.00"))
    ;
  }

  public float ReturnAnswer()
  {
    return time;
  }
}
