using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionPlano : MonoBehaviour
{
    public GameObject timer;
    public Slider sliderMassa;
    public Text textoMassa;
    public Slider sliderAtrito;
    public Text textoAtrito;
    public Slider sliderForca;
    public Text textoForca;
    public int indice;

    private CSVfile csvfile;

    void Awake()
    {
        indice = 0;
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

        sentencas.Add(GetExample());

        return sentencas.ToArray();    
    }

    public string GetQuestion(int index)
    {
        List<string> allquestion = csvfile.ReadCSVFile("plano_exemple");
        return allquestion[index];
    }

    public string GetExample()
    {
         List<string> allquestion = csvfile.ReadCSVFile("plano_exemple");

         if(this.indice == 0)
         {
             Debug.Log("Angulo: 45  Atrito: 0.3");
         }
         else if(this.indice == 1)
         {
             Debug.Log("Massa: 2  Angulo:  60  Forca:  ~17.3");
         }
         else if(this.indice == 2)
         {
             Debug.Log("Angulo: 30  Massa: 4  Forca: 20");
         }

         string question = allquestion[this.indice];

         return question;
     }
}
