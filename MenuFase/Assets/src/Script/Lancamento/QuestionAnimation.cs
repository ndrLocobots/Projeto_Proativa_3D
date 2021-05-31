using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class QuestionAnimation : MonoBehaviour
{
    private Transform altar;
    private bool isQuestion;
    public Animator panel_victory, panel_lose;
    private Tutorial tutorial;
    private ScenaAnimation lancamentoAnimation;

    private GenericAnimations ScenaAnimation;

    private heart hearts;
    private dialog robotDialog;

    private Teleporter tele;

    private int attemptsNum = 3;

    private int index;
    private int showAltarIndex = 5;
    private int changeAltarIndex = 6;
    private int showCameraIndex = 1;
    private int questionIndex = 8;
    private int levelIndex = 0;

    private ControleQuestoes controle;
    private bool acerto;

    public GameObject cam;
    public GameObject cube;
    public ScreenResults screenResults;
    public GameObject screen;
    public SoundsAnimationL sound;
    public Button start, restore, menu;

    void Start()
    {
        tutorial = FindObjectOfType<Tutorial>();
        lancamentoAnimation = FindObjectOfType<ScenaAnimation>();
        ScenaAnimation = FindObjectOfType<GenericAnimations>();
        controle = FindObjectOfType<ControleQuestoes>();
        robotDialog = FindObjectOfType<dialog>();
        hearts = FindObjectOfType<heart>();
        tele = FindObjectOfType<Teleporter>();

        controle.AtualizaQuestaoAtiva(levelIndex);

        altar = tele.gameObject.transform;

        isQuestion = false;
        acerto = false;
        panel_victory.SetBool("action", false);
        panel_lose.SetBool("action", false);
    }

    public void BackSentence()
    {
        if (!tutorial.isTutorial)
        {
            robotDialog.BackSentence();
        }
    }

    public void NextSentence()
    {
        if (!tutorial.isTutorial)
        {
            index = robotDialog.NextSentence();
            SetAnimation(index);
        }
    }

    public void SetAnimation(int index)
    {
        if (index == showAltarIndex)
        {

            ChangeMusic.Instancia.TrocarParaMusicaSecundaria();
            StartCoroutine(ActiveCameraAnimation());

        }
        else if (index == changeAltarIndex)
        {
            lancamentoAnimation.ChangeTeleporterPosition();
        }
        else if (index == showCameraIndex)
        {
            lancamentoAnimation.StartTutorial();
        }
        else if (index == questionIndex && !isQuestion)
        {
            hearts.updateOpacityHearts(1);
            isQuestion = true;
        }
    }

    IEnumerator ActiveCameraAnimation()
    {
        cube.GetComponent<CuboLan>().AnimationConfig();

        yield return new WaitForSeconds(lancamentoAnimation.AnimatorCamera() + 0.3f);

        position camera = cam.GetComponent<position>();
        camera.SliderAux(camera.getSliderOption());
    }

    public void isQuestionRight()
    {
        if (isQuestion && !tutorial.isTutorial)
        {

            Vector3 distaceDelta = altar.position - transform.position;

            if (distaceDelta.magnitude < 5)
            {
                CorrectAnswer();
            }
            else
            {
                WrongAnswer();
            }
        }
    }

    void CorrectAnswer()
    {
        acerto = true;
        screenResults.UpdateResultsText(acerto);
        lancamentoAnimation.HideEnemy();
        StartCoroutine(ScenaAnimation.ShowReactionOfRobot(true));
        StartCoroutine(ActiveWinAnimation());
        controle.AtualizaQuestaoAtiva(levelIndex + 1);
        controle.setConcluidas(1, levelIndex);
        StartCoroutine(Wait());

        if (levelIndex <= 3)
            levelIndex++;

        if (levelIndex == 3)
            panel_victory.SetBool("action", true);

        tele.setAtingido(true);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.5f);
        sound.PlayPortal();

    }

    void WrongAnswer()
    {
        acerto = false;
        screenResults.UpdateResultsText(acerto);
        lancamentoAnimation.ActiveEnemy();
        StartCoroutine(ScenaAnimation.ShowReactionOfRobot(false));
        robotDialog.SetSadBubble();
        ReduceAttemptsNumber();
        sound.PlayEnemy();
    }

    void ReduceAttemptsNumber()
    {
        attemptsNum--;
        hearts.loseHeart();

        if (attemptsNum == 0)
        {
            StartCoroutine(ActiveLoseAnimation());
            panel_lose.SetBool("action", true);

        }
    }

    IEnumerator ActiveLoseAnimation()
    {
        cube.GetComponent<CuboLan>().AnimationConfig();
        yield return new WaitForSeconds(ScenaAnimation.AnimationToLose());
        lancamentoAnimation.HideEnemy();

        RestoreCena();
        robotDialog.ActivateBubbleSignal();
    }

    IEnumerator ActiveWinAnimation()
    {
        cube.GetComponent<CuboLan>().AnimationConfig();

        yield return new WaitForSeconds(ScenaAnimation.AnimationToWin());

        RestoreCena();
        StartCoroutine(ShowResults());

        robotDialog.ActivateBubbleOtherQuestion();
        lancamentoAnimation.ChangeQuestion();
    }

    void RestoreCena()
    {
        attemptsNum = 3;
        isQuestion = false;

        position camera = cam.GetComponent<position>();
        camera.SliderAux(camera.getSliderOption());

        cube.GetComponent<CuboLan>().ClickRestore(true);
        hearts.updateOpacityHearts(0);
    }

    IEnumerator ShowResults()
    {
        screen.SetActive(true);

        menu.interactable = false;
        start.interactable = false;
        restore.interactable = false;

        yield return new WaitForSeconds(5);

        screen.SetActive(false);

        menu.interactable = true;
        start.interactable = true;
        restore.interactable = true;
    }
}
