using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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

    bubbleText.text = "Parabéns você conseguiu !!!";
  }

  public void SetSadBubble()
  {

    bubbleText.text = "Foi quase, tente de novo !!!";
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

    yield return new WaitForSeconds(10);
    speechBubble.SetActive(false);
  }

  public void ActivateBubbleSignal()
  {
    bubbleText.text = "clique em mim !!!";
    speechBubble.SetActive(true);
  }

  public void ActivateBubbleOtherQuestion(){
    bubbleText.text = "Parabéns, tente outra questão";
    speechBubble.SetActive(true);
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
