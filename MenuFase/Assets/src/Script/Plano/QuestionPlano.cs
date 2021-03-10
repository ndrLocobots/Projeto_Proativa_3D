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

    private CSVfile csvfile;

    private int indiceJaSorteado;
    public int indice;

    void Awake()
    {
        csvfile = gameObject.AddComponent<CSVfile>();
        SetRobotDialog();
        
        timer.GetComponent<Text>().enabled = false;
        indiceJaSorteado = -1;
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

    public string GetExample()
    {
    
         List<string> allquestion = csvfile.ReadCSVFile("plano_exemple");
         indice = Random.Range(0, allquestion.Count);

         if(indice == 0)
         {
             Debug.Log("Angulo: 45  Atrito: 0.3");
         }
         else
         {
             Debug.Log("Massa: 2  Angulo:  60  Forca:  ~17.3");
         }

         string question = allquestion[indice];
    
         return question;
     }
}
