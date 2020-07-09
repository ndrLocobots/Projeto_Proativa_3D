using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
public class answerEffect : MonoBehaviour
{
  public GameObject robotDialog;
  public GameObject altar;
  public GameObject inimigo;
  public GameObject cam;
  public GameObject cube;

  public PlayableDirector enemyAnimation, cameraAnimation;

  int showAltarIndex = 3;
  int changeAltarIndex = 4;
  int showCameraIndex = 1;
  int index = 0;

  bool isQuestion, changedPosition, isTutorial;
  int tryNumber = 3;

  float distaceDelta;

  Tutorial tutorial;
  Question question;

  void Start()
  {
    tutorial = FindObjectOfType<Tutorial>();
    question = FindObjectOfType<Question>();

    robotDialog.GetComponent<dialog>().setences = question.GetSetences();
    distaceDelta = question.distaceDelta;

    isQuestion = false;
    changedPosition = false;
  }

  public void BackSentence()
  {
    if (!tutorial.isTutorial)
    {
      index = robotDialog.GetComponent<dialog>().BackSentence();
    }
  }

  public void NextSentence()
  {
    if (!tutorial.isTutorial)
    {
      index = robotDialog.GetComponent<dialog>().NextSentence();
      SetAnimation(index);
      isQuestion = true;
    }
  }

  void SetAnimation(int index)
  {
    if (index == showAltarIndex)
    {
      AnimatorCamera();
    }
    else if (index == changeAltarIndex)
    {
      ChangeAltarPosition();
    }
    else if (index == showCameraIndex)
    {
      StartTutorial();
    }
  }

  void AnimatorCamera()
  {
    cameraAnimation.Play();
  }

  void ChangeAltarPosition()
  {
    if (!changedPosition)
    {
      changedPosition = true;
      altar.GetComponent<altarPosition>().ChangeAltarPosition(distaceDelta);
    }
  }

  void StartTutorial()
  {
    tutorial.StartTutorial();
  }

  void UpdateAttempts()
  {
    tryNumber--;

    if (tryNumber == 0)
    {
      StartCoroutine(AnimationToLose());
    }
  }

  IEnumerator AnimationToLose()
  {
    cam.GetComponent<position>().SliderAux(0);
    enemyAnimation.Play();

    yield return new WaitForSeconds((float)enemyAnimation.duration - 1f);

    ActiveEnemy();
    ReestoreCena();
  }

  public void ActiveEnemy()
  {
    Vector3 distaceDelta = altar.transform.position - transform.position;

    if (distaceDelta.magnitude > 10 && isQuestion)
    {

      enemy[] inimigos = inimigo.GetComponentsInChildren<enemy>();
      foreach (enemy inimigo in inimigos)
      {
        inimigo.activeEnemy();
      }

      UpdateAttempts();
    }
  }

  void ReestoreCena()
  {
    tryNumber = 3;
    isQuestion = false;
    changedPosition = false;

    cam.GetComponent<position>().SliderAux(1);
    cube.GetComponent<CuboLan>().ClickRestore(true);
    Debug.Log("You lose");
  }

}
