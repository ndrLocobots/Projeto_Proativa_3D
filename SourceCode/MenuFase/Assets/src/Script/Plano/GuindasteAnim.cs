using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuindasteAnim : MonoBehaviour
{
    [SerializeField]
    Animator guindaste;

    [SerializeField]
    private MeshRenderer cuboRender;

    public void FinalizaAnimGuindaste()
    {
        guindaste.SetBool("Idle", true);
        guindaste.SetBool("Puxa20", false);
        guindaste.SetBool("Puxa30", false);
        guindaste.SetBool("Puxa45", false);
        guindaste.SetBool("Puxa60", false);
    }

    public void SomeCubo()
    {
        cuboRender.enabled = false;
    }
}
