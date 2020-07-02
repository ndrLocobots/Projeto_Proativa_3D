using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class dialog : MonoBehaviour
{
  public TextMeshProUGUI textDisplay;
  public GameObject panel;

  Animator robotAnimator;

  public string[] setences;
  private int index = 0;
  private float typingSpeed = 0.03f;
  public bool isTalk = false;

  void Start()
  {
    robotAnimator = GetComponent<Animator>();
    panel.SetActive(false);
    robotAnimator.SetBool("isTalk", false);
  }

  IEnumerator Type()
  {
    foreach (char letter in setences[index].ToCharArray())
    {
      textDisplay.text += letter;
      yield return new WaitForSeconds(typingSpeed);
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

  public void NextSentence()
  {
    if (index < setences.Length - 1)
    {
      index++;
      Talk();
    }
    else
    {
      StopTalk();
    }
  }

  public void Talk()
  {
    isTalk = true;

    StopAllCoroutines();
    textDisplay.text = "";
    panel.SetActive(true);

    robotAnimator.SetBool("isTalk", true);
    StartCoroutine(Type());
  }

  public void StopTalk()
  {
    isTalk = false;

    robotAnimator.SetBool("isTalk", false);
    panel.SetActive(false);
  }


}
