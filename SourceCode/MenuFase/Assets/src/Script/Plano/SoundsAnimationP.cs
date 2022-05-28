using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsAnimationP : MonoBehaviour
{
    public AudioSource enemy;
    public AudioSource portal;
    public AudioSource cubo;

    public void PlayEnemy()
    {
        enemy.Play();
    }
    public void PlayPortal()
    {
        portal.Play();
    }
    public void PlayCubo()
    {
        cubo.Play();
    }
}
