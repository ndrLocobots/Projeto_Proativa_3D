using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimInimigo : MonoBehaviour
{
    public Animator inimigo1;
    public Animator inimigo2;

    public void AnimaInimigo(int index)
    {
        if(index == -1)
        {
            inimigo1.SetBool("Idle", false);
            inimigo2.SetBool("Idle", false); 
        }
        else if(index == 0)
        {
            inimigo1.SetBool("Idle", true);
            inimigo2.SetBool("Idle", true);
        }
        else if(index == 1)
        {
            inimigo1.SetTrigger("01");
            inimigo2.SetTrigger("01");
        }
        else if(index == 2)
        {
            inimigo1.SetTrigger("02");
            inimigo2.SetTrigger("02");
        }
        else if(index == 3)
        {
            inimigo1.SetTrigger("03");
            inimigo2.SetTrigger("03");
        }
        else
        {
            inimigo1.SetTrigger("04");
            inimigo2.SetTrigger("04");
        }
    }
}
