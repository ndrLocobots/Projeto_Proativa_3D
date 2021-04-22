using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class ScenaAnimation : MonoBehaviour
{
  public PlayableDirector cameraAnimation;
  
  public GameObject inimigo;

  private Tutorial tutorial;
  private Question question;
  private robotAnimation robot;
  private Teleporter teleporter;

  public GameObject respostas;

  void Start()
  {
    question = FindObjectOfType<Question>();
    tutorial = FindObjectOfType<Tutorial>();
    teleporter = FindObjectOfType<Teleporter>();
    robot = FindObjectOfType<robotAnimation>();
  }

  void FixedUpdate()
  {
    if (Input.GetKeyDown(KeyCode.H))
    {
      respostas.GetComponent<Text>().text = question.ReturnAnswer();
      respostas.SetActive(!respostas.activeSelf);
    }
  }

  public float AnimatorCamera()
  {
    cameraAnimation.Play();

    return (float)cameraAnimation.duration;
  }

  public void ChangeQuestion()
  {
    question.SetRobotDialog();
    ChangeTeleporterPosition();
  }

  public void ChangeTeleporterPosition()
  {
    teleporter.ChangeTeleporterPosition(question.distaceDelta);
    teleporter.ativaIdle();
  }

  public void StartTutorial()
  {
    tutorial.StartTutorial();
  }

  public void ActiveEnemy()
  {
    enemy[] inimigos = inimigo.GetComponentsInChildren<enemy>();
    foreach (enemy inimigo in inimigos)
    {
      inimigo.activeEnemy();
    }
  }

  public void HideEnemy()
  {
    enemy[] inimigos = inimigo.GetComponentsInChildren<enemy>();
    foreach (enemy inimigo in inimigos)
    {
      inimigo.HideEnemy();
    }
  }

  public Question getQuestion()
  {
    return this.question;
  }
}
