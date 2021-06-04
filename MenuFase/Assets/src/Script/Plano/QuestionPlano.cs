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
    [SerializeField]
    private StartSimulation start;

    void Awake()
    {
        indice = 0;
        csvfile = gameObject.AddComponent<CSVfile>();
        SetRobotDialog();
        
        timer.GetComponent<Text>().enabled = false;
    }

    public void SetRobotDialog()
    {
        dialog robotDialog = FindObjectOfType<dialog>();

        if (robotDialog)
        {
            robotDialog.setences = GetDialog();
        }
    }

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

    private string MakeQuestionData(int indice, string question)
    {
        if(indice == 0)
        {  
            int angIndex = (int)Random.Range(0, 4);

            float[] angulos = new float[4] {20f, 30f, 45f, 60f};
            float[] aceleracoes = new float[4] {1.70f, 2.50f, 4.85f, 5.25f};
            float[] atritos = new float[4] {0.18f, 0.28f, 0.30f, 0.66f};
            int[] indiceAtritos = new int[4] {5, 10, 11, 25};

            question = question.Replace("{ag}", angulos[angIndex].ToString()).Replace(
                             "{ac}", aceleracoes[angIndex].ToString());
            Debug.Log("Angulo: " + angulos[angIndex] + " Atrito: " + atritos[angIndex]);

            start.setRespostasCorretas(angIndex, indiceAtritos[angIndex], 0, 0);
        }
        else if(indice == 1)
        {
            int massIndex = (int)Random.Range(1f, 10f);
            int angIndex = (int)Random.Range(0, 3f);

            float[] angulos = new float[4] {20f, 30f, 45f, 60f};
            float forca = (float)(9.8 * massIndex * Mathf.Sin((angulos[angIndex] * Mathf.PI) / 180));

            question = question.Replace("{ag}", angulos[angIndex].ToString()).Replace(
                                        "{ms}", massIndex.ToString());
            Debug.Log("Massa: " + massIndex + " Angulo: " + angulos[angIndex] + "Forca: ~" + forca);
            start.setRespostasCorretas(angIndex, 0, massIndex, forca);
            
        }
        else if(indice == 2)
        {
            int angIndex = (int)Random.Range(0, 3f);   
        }

        return question;
    }

    public string GetExample()
    {
         List<string> allquestion = csvfile.ReadCSVFile("plano_exemple");
         string question = allquestion[this.indice];

         if(this.indice == 0)
         {
             question = MakeQuestionData(0, question);
         }
         else if(this.indice == 1)
         {
             question = MakeQuestionData(1, question);
         }
         else if(this.indice == 2)
         {
             Debug.Log("Angulo: 30  Massa: 4  Forca: 20");
             start.setRespostasCorretas(1, 0, 4, 20);
         }

         

         return question;
     }
}
