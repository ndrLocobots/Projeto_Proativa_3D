using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsAnimationQ : MonoBehaviour
{
    public AudioSource fallingBuilding;
    public AudioSource wrongAnswer;
    public AudioSource rightAnswer;

    public void Play_fallingBuilding()
    {
        fallingBuilding.Play();
    }
    public void Play_wrongAnswer()
    {
        wrongAnswer.Play();
    }
    public void Play_rightAnswer()
    {
        rightAnswer.Play();
    }
}
