using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MudaRigidez : MonoBehaviour
{
    public SpringJoint mola;
    public Text textoMola;

    public void MudRigidez(float v)
    {
        mola.damper = v;
        AtualizaTexto(v);
    }

    public void AtualizaTexto(float v)
    {
        textoMola.text = "Rigidez: " + v.ToString("F2");
    }
}
