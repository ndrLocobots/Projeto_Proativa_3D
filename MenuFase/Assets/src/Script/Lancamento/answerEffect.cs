using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answerEffect : MonoBehaviour
{
  public string[] setencas;

  public GameObject robotDialog;
  public GameObject altar;
  public GameObject inimigo;
  public GameObject cam;

  public int showCameraIndex;
  public int changeAltarIndex;
  int index = 0;


  void Start()
  {
    robotDialog.GetComponent<dialog>().setences = setencas;
  }

  public void BackSentence()
  {
    index = robotDialog.GetComponent<dialog>().BackSentence();
  }

  public void NextSentence()
  {
    index = robotDialog.GetComponent<dialog>().NextSentence();

    if (index == showCameraIndex)
    {
      AnimatorCamera();
    }
    else if (index == changeAltarIndex)
    {
      ChangeAltarPosition();
    }
  }

  void AnimatorCamera()
  {
    cam.GetComponent<cameraControl>().AnimatorCamera();
  }

  void ChangeAltarPosition()
  {
    altar.GetComponent<altarPosition>().ChangeAltarPosition();
  }

  public void ActiveEnemy()
  {
    Vector3 deltaDistance = altar.transform.position - transform.position;

    if (deltaDistance.magnitude > 10)
    {
      
      enemy[] inimigos = inimigo.GetComponentsInChildren<enemy>();
      foreach (enemy inimigo in inimigos)
      {
        inimigo.activeEnemy();
      }

    }
  }
}
