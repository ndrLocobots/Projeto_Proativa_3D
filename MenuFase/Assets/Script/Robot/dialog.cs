using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class dialog : MonoBehaviour
{
  public TextMeshProUGUI textDisplay;

  private Animator robotAnimator;
  public GameObject panel, robot;
  public string[] setences;
  private int index;
  private float typingSpeed = 0.03f;
  private bool isTalk = false;
  void Start()
  {
    robotAnimator = robot.GetComponent<robotAnimation>().robotAnimator;

    panel.SetActive(false);
    textDisplay.text = "";
    StartCoroutine(Type());
  }

  void Update()
  {
    isTalk = robotAnimator.GetBool("isTalk");

    if (isTalk)
    {
      panel.SetActive(true);
      textDisplay.text = "";
      StartCoroutine(Type());
    }
    else
    {
      panel.SetActive(false);
    }

  }
  IEnumerator Type()
  {
    foreach (char letter in setences[index].ToCharArray())
    {
      textDisplay.text += letter;
      yield return new WaitForSeconds(typingSpeed);
    }
  }

  public void NextSentence()
  {
    if (index < setences.Length - 1)
    {
      index++;
      StopAllCoroutines();
      textDisplay.text = "";
      StartCoroutine(Type());
    }
    else
    {
      StopAllCoroutines();
      textDisplay.text = "";
      isTalk = false;
      robotAnimator.SetBool("isTalk", false);
    }
  }

  public void BackSentence()
  {
    if (index > 0)
    {
      index--;
      StopAllCoroutines();
      textDisplay.text = "";
      StartCoroutine(Type());
    }
  }
}
