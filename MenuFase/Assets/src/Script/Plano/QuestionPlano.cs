using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionPlano : MonoBehaviour
{
    public GameObject timer;

    private CSVfile csvfile;

    void Awake()
    {
        csvfile = gameObject.AddComponent<CSVfile>();
        SetRobotDialog();
        
        timer.GetComponent<Text>().enabled = false;
    }

    public void SetRobotDialog()
    {
        //MakeQuestionData();

        dialog robotDialog = FindObjectOfType<dialog>();

        if (robotDialog)
        {
            robotDialog.setences = GetDialog();
        }
    }

    // private void MakeQuestionData()
    // {

    // }

    private string[] GetDialog()
    {
        List<string> sentencas = new List<string>();
        sentencas = csvfile.ReadCSVFile("plano_inclinado_dialog");

        //sentencas.Add(GetExample());

        return sentencas.ToArray();    
    }

    // private string GetExample()
    // {
    
    //     List<string> allquestion = csvfile.ReadCSVFile("lancamento_exemple");
    //     int indice = Random.Range(0, allquestion.Count - 1);

    //     string question = allquestion[indice];
    
    //     return question.Replace("{t}", time.ToString("0.00"))
    //     .Replace("{dx}", distaceDelta.ToString("0.00"))
    //     .Replace("{vx}", velocityX.ToString("0.00"))
    //     .Replace("{vy}", velocityY.ToString("0.00"))
    //     .Replace("{mh}", maxHeight.ToString("0.00"))
    //     .Replace("{th}", (time/2).ToString("0.00"))
    //     .Replace("{a}", (angle).ToString("0.00"))
    //     ;
    // }
}
