using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawToDots : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject brush;

    LineRenderer currentLineRenderer;

    Vector2 lastPos;

    private void Update()
    {
        Draw();
    }

    private void Draw()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CreateBrush();
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            if (mousePos != lastPos)
            {
                AddAPoint(mousePos);
                lastPos = mousePos;
            }
            
        }
        else
        {
            currentLineRenderer = null;
        }
    }

    private void CreateBrush()
    {
        GameObject brushInstance = Instantiate(brush);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();

        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);

    }

    private void AddAPoint(Vector2 pointPos) 
    {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        currentLineRenderer.SetPosition(positionIndex, pointPos);
    }
}
