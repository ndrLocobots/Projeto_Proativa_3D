using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MudaComp : MonoBehaviour
{
    public GameObject massa;
    public SpringJoint sj;

    public void ChangeComp(float transf)
    {
        

        massa.transform.position = new Vector3(massa.transform.position.x - transf, massa.transform.position.y, massa.transform.position.z);
    }
}
