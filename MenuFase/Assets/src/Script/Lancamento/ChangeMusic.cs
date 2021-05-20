using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSourceTutorial;
    [SerializeField] private AudioSource _audioSourceSecondary;

    [SerializeField] private Animator _animator;

    public static ChangeMusic Instancia;

    private void Awake()
    {
        Instancia = this;
    }

    public void TrocarParaMusicaSecundaria()
    {
        //Coloca a música no audio source secundário
        //_audioSourceSecondary.clip = musica;

        //Pega o tempo da música principal
        _audioSourceSecondary.time = _audioSourceTutorial.time;

        //Toca a música secundária
        _audioSourceSecondary.Play();

        //Troca para a música secundária
        _animator.Play("secondary_musicEnter");

        //Chama Coroutine para parar a música principal
        StartCoroutine(PararAudioSource(_audioSourceTutorial));
    }

   

    private IEnumerator PararAudioSource(AudioSource audioSource)
    {
        //Espera 1 segundo para esperar acabar a transição
        yield return new WaitForSeconds(2.5f);
        audioSource.Stop();
    }
}
