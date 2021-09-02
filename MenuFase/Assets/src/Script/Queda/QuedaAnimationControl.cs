using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class QuedaAnimationControl : MonoBehaviour
{
    private bool isQuestion;

    [SerializeField]
    private GenericAnimations cenaAnimation;

    [SerializeField]
    private heart hearts;

    public Animator panel_victory, panel_lose;

    [SerializeField]
    private dialog robotDialog;

    [SerializeField]
    private QuestionQueda question;

    [SerializeField]

    private int attemptsNum = 3;

    private int index;
    private int showInimigo = 2;
    private bool estaResolvendo;
    private float tempoInicio;

    private ControleQuestoes controleQuestoes;

    private int questionIndex = 3;
    private int i = 1;

    public GameObject secondCamera;
    public GameObject cube;
    public float volume = 0.5f;

    public SoundsAnimationQ sound;
    public GameObject p_vic, p_los;
    public float tempo;

    void Start()
    {
        cenaAnimation = FindObjectOfType<GenericAnimations>();
        robotDialog = FindObjectOfType<dialog>();
        hearts = FindObjectOfType<heart>();
        question = FindObjectOfType<QuestionQueda>();
        controleQuestoes = FindObjectOfType<ControleQuestoes>();
        controleQuestoes.AtualizaQuestaoAtiva(0);

        isQuestion = false;
        estaResolvendo = false;

        p_vic.SetActive(true);
        p_los.SetActive(true);
        panel_victory.SetBool("action", false);
        panel_lose.SetBool("action", false);

    }

    void Update()
    {
        if (estaResolvendo && !robotDialog.isTalk)
        {
            if (Time.time - tempoInicio >= 25)
            {
                robotDialog.ActivateBubbleReminder();
                robotDialog.TalkWithBubble();
                tempoInicio = Time.time;
                estaResolvendo = false;
            }
        }
    }

    public void BackSentence()
    {
        robotDialog.BackSentence();
    }

    public void NextSentence()
    {
        index = robotDialog.NextSentence();
        SetAnimation(index);

    }

    public void SetAnimation(int index)
    {
        if (index == showInimigo)
        {
            //cenaAnimation.AnimatorCamera();
        }
        else if (index >= questionIndex && !isQuestion)
        {
            hearts.updateOpacityHearts(1);
            isQuestion = true;
        }
    }

    public void isQuestionRight(float[] userAnswers)
    {
        if (isQuestion)
        {
            float[] answers = question.ReturnAnswer();

            if(answers.Length == 2)
            {
              if(userAnswers[0] == answers[0] && userAnswers[1] == answers[1])
              {
                CorrectAnswer();
                question.SetRobotDialog();
              }
              else
                WrongAnswer(userAnswers);
            }
            else
            {
              if(userAnswers[0] == answers[0] && userAnswers[1] == answers[1] && userAnswers[2] == answers[2])
              {
                CorrectAnswer();
                question.SetRobotDialog();
              }
              else
                WrongAnswer(userAnswers);
            }
        }
    }

    void CorrectAnswer()
    {
        StartCoroutine(cenaAnimation.ShowReactionOfRobot(true));
        StartCoroutine(ActiveWinAnimation());
        controleQuestoes.AtualizaQuestaoAtiva(i);
        controleQuestoes.setConcluidas(1, i - 1);
        sound.Play_rightAnswer();

        if (i <= 3)
            i++;

        if (i == 4)
            StartCoroutine(WaitV());
    }

    IEnumerator ActiveWinAnimation()
    {
        yield return new WaitForSeconds(cenaAnimation.AnimationToWin());
        RestoreCena();
        robotDialog.ActivateBubbleOtherQuestion();
    }

    void WrongAnswer(float[] wrongAnswers)
    {
        attemptsNum--;
        hearts.loseHeart();
        sound.Play_wrongAnswer();


        if (attemptsNum == 0)
        {

            sound.Play_fallingBuilding();
            StartCoroutine(ActiveLoseAnimation());
            StartCoroutine(WaitL());
        }
        else
        {
            StartCoroutine(cenaAnimation.ShowReactionOfRobot(false));
            robotDialog.SetSadBubble();

            float time = Mathf.Sqrt((2 * wrongAnswers[0]) / wrongAnswers[1]);

            StartCoroutine(ActiveWrongAnimation(time));
        }
    }

    IEnumerator ActiveLoseAnimation()
    {
        RestoreCena();
        yield return new WaitForSeconds(cenaAnimation.AnimationToLose());
        RestoreCena();
        robotDialog.ActivateBubbleSignal();

    }

    IEnumerator ActiveWrongAnimation(float time)
    {
        secondCamera.SetActive(true);
        yield return new WaitForSeconds(cenaAnimation.AnimationToWrongAnswer());
        secondCamera.SetActive(false);
    }
    IEnumerator WaitL()
    {
        yield return new WaitForSeconds(tempo);
        panel_lose.SetBool("action", true);

    }

    IEnumerator WaitV()
    {
        yield return new WaitForSeconds(tempo);
        panel_victory.SetBool("action", true);
    }
    void RestoreCena()
    {
        attemptsNum = 3;
        isQuestion = false;
        secondCamera.SetActive(false);

        cube.GetComponent<Control>().RestartButton();
        hearts.updateOpacityHearts(0);
    }

    public void setEstResolvendo(bool valor)
    {
        this.estaResolvendo = valor;
    }

    public void setTempoInicio()
    {
        this.tempoInicio = Time.time;
    }

}
