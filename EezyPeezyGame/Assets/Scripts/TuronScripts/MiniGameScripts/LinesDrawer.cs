using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Logic for drawing lines in abandoned minigame

public class LinesDrawer : MonoBehaviour
{
    public GameObject linePrefab;

    [Space(30f)]
    public Gradient lineColor;
    public float LinePointsMinDistance, lineWidth;

    Line currentLine;

    Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if ( Input.GetMouseButtonDown(0))
        {
            BeginDraw();
        }
        if (currentLine != null)
        {
            Draw();
        }
        if (Input.GetMouseButtonUp(0))
        {
            EndDraw();
        }
    }

    void BeginDraw()
    {
        currentLine = Instantiate(linePrefab, this.transform).GetComponent<Line>();
        currentLine.UsePhysics(false);
        currentLine.SetLineColor(lineColor);
        currentLine.SetPointsMinDistance(LinePointsMinDistance);
        currentLine.SetLineWidth(lineWidth);
    }
    void Draw()
    {
        Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        currentLine.AddPoint(mousePosition);
    }

    void EndDraw()
    {
        if (currentLine != null)
        {
            if (currentLine.pointsCount<2)
            {
                Destroy(currentLine.gameObject);
            }
            else
            {
                currentLine.UsePhysics(true);
                currentLine = null;
            }
        }
    }
}
