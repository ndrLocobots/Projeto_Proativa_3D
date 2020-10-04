using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heart : MonoBehaviour
{

  public Image[] hearts;
  int index = 0;

  void Start()
  {
    updateOpacityHearts(0);
  }

  public void loseHeart()
  { 
    var tempColor = hearts[index].color;
    tempColor.r = 0;

    hearts[index].color = tempColor;
    index++;
  }

  public void updateOpacityHearts(float opacity)
  {
    Color tempColor;

    foreach (Image heart in hearts)
    {
      tempColor = heart.color;

      tempColor.a = opacity;
      tempColor.r = 1;

      heart.color = tempColor;
    }

    index = 0;
  }
}
