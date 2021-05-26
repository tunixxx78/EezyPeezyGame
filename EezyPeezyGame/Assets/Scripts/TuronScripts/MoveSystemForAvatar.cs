using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSystemForAvatar : MonoBehaviour
{
    public GameObject correctShape;
    private bool moving, finish;

    private float startPosX, startPosY;

    private Vector3 resetPosition;

    private void Start()
    {
        resetPosition = this.transform.localPosition;
    }

    private void Update()
    {
        if (finish == false)
        {
            if (moving)
            {
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.localPosition.z);

            }
        }

    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            moving = true;
        }
    }

    private void OnMouseUp()
    {
        moving = false;

        if (Mathf.Abs(this.transform.localPosition.x - correctShape.transform.localPosition.x) <= 0.5f && Mathf.Abs(this.transform.localPosition.y - correctShape.transform.localPosition.y) <= 0.5f)
        {
            this.transform.position = new Vector3(correctShape.transform.position.x, correctShape.transform.position.y, correctShape.transform.position.z);
            finish = true;

            GameObject.Find("MoveOn").GetComponent<AvatarSelection>().AddPoints();
        }
        else
        {
            this.transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
        }
    }
}
