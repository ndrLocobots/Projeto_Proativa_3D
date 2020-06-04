using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotClick : MonoBehaviour
{
    Animator robotAnimator;
    public bool mouseOnCollider = false;
    int danceHash = Animator.StringToHash("isDance");
    void Start()
    {
        robotAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseOnCollider){
          if(Input.GetMouseButtonDown(0)){
            robotAnimator.SetTrigger(danceHash);
          }
        }
    }

    void OnMouseEnter(){
      mouseOnCollider = true;
    }

    void OnMouseExit(){
      mouseOnCollider = false;
    }
}
