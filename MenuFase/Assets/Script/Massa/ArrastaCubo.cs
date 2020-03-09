using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(MeshCollider))]

public class ArrastaCubo : MonoBehaviour
{
    public Vector3 screenPoint;
    public Vector3 offset;
    public Vector3 scanPos;

    public GameObject mola;
    public SpringJoint sj;
    public Rigidbody massa;

    private bool canDrag, isDragging;

    private float oldX, currX, dragSpeed;

    void Update()
    {
        scanPos = transform.position;

        oldX = currX;
        currX = transform.position.x;


        if (sj.damper == 0)
            dragSpeed = 1;
        else
            dragSpeed = (-0.43f * sj.damper) + 1;
        if (transform.position.x > -33.2f && transform.position.x < -28.7f)
            canDrag = true;
        else
            canDrag = false;

        if(currX != 0 && oldX != 0)
            AnimaMola(oldX, currX);
    }

    void AnimaMola(float oldX, float currX)
    {
        mola.transform.localScale += new Vector3(0, (currX - oldX) / 31.54f, 0);
    }

    void OnMouseDown()
    {
        isDragging = true;

        screenPoint = Camera.main.WorldToScreenPoint(scanPos);
        offset = scanPos - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x * dragSpeed, screenPoint.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        if (canDrag)
        {
            isDragging = true;

            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x * dragSpeed, screenPoint.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

            transform.position = curPosition;
        }
        else
            OnMouseUp();

    }

    private void OnMouseUp()
    {
        isDragging = false;
        Input.ResetInputAxes();
    }

    public bool GetDrag()
    {
        return this.isDragging;
    }
}