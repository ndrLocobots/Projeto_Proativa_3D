using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class dialog : MonoBehaviour
{
  public TextMeshProUGUI textDisplay;
  public TextMeshPro bubbleText;
  public GameObject panel, speechBubble;

  robotAnimation robotAnimator;

  public string[] setences;
  private int index = 0;
  private float typingSpeed = 0.02f;
  public bool isTalk = false;

  public Button start, restore, menu;

  void Start()
  {
    robotAnimator = FindObjectOfType<robotAnimation>();
    panel.SetActive(false);
    robotAnimator.RobotTalk(false);
    ActivateBubbleSignal();

    //bubbleText = speechBubble.GetComponent<TextMeshPro>();
  }

  public int BackSentence()
  {
    if (index > 0)
    {
      index--;
      StopAllCoroutines();
      textDisplay.text = "";
      StartCoroutine(Type());
    }

    return index;
  }

  public int NextSentence()
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

    return index;
  }

  public void Skip (){
    StopAllCoroutines();
    textDisplay.text = setences[index];
  }
  
  public void Talk()
  {
    isTalk = true;

    StopAllCoroutines();
    textDisplay.text = "";
    panel.SetActive(true);
    DeactivateBubble();

    robotAnimator.RobotTalk(true);
    StartCoroutine(Type());
  }

  public void StopTalk()
  {
    isTalk = false;

    robotAnimator.RobotTalk(false);
    panel.SetActive(false);
  }

  IEnumerator Type()
  {
    foreach (char letter in setences[index].ToCharArray())
    {
      textDisplay.text += letter;
      yield return new WaitForSeconds(typingSpeed);
    }
  }

  public void SetHappyBubble()
  {
    bubbleText.fontSize = 5;
    bubbleText.text = "Parabéns, você conseguiu!";
  }

  public void SetSadBubble()
  {
    bubbleText.fontSize = 5;
    bubbleText.text = "Foi quase, tente de novo!";
  }

  public void TalkWithBubble()
  {
    if (!speechBubble.activeSelf)
    {
      StartCoroutine(AnimationForBubble());
    }
  }

  IEnumerator AnimationForBubble()
  {
    speechBubble.SetActive(true);

    yield return new WaitForSeconds(12);
    speechBubble.SetActive(false);
  }

  public void ActivateBubbleSignal()
  {
    bubbleText.fontSize = 6;
    bubbleText.text = "Clique em mim!";
    speechBubble.SetActive(true);
  }

  public void ActivateBubbleOtherQuestion(){
    start.interactable = false;
    restore.interactable = false;
    menu.interactable = false;

    bubbleText.fontSize = 4;
    bubbleText.text = "Parabéns! Clique em mim para outra questão.";
    this.TalkWithBubble();
  }

  public void ActivateBubbleReminder()
  {
    bubbleText.fontSize = 4;
    bubbleText.text = "Esqueceu o enunciado? Clique em mim!";
  }
  
  public void DeactivateBubble()
  {
    speechBubble.SetActive(false);
  }

  public void SetIndex(int valor)
  {
    this.index = this.index + valor;
  }

}
