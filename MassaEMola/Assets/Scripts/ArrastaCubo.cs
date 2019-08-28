using UnityEngine;
using System.Collections;
[RequireComponent(typeof(MeshCollider))]

public class ArrastaCubo : MonoBehaviour
{
    public Vector3 screenPoint;
    public Vector3 offset;
    public Vector3 scanPos;

    public GameObject mola;
    public Rigidbody massa;

    private float oldX, currX;

    void Update()
    {
        scanPos = transform.position;

        oldX = currX;
        currX = transform.position.x;
        
        if(currX != 0 && oldX != 0)
        {
            AnimaMola(oldX, currX);
        }
    }

    void AnimaMola(float oldX, float currX)
    {
        mola.transform.localScale += new Vector3(0, (currX - oldX) / 31.54f, 0);
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(scanPos);
        offset = scanPos - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

        //AnimaMola(oldX, currX);

        transform.position = curPosition;
    }
}