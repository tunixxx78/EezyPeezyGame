using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//creating pencil for conecting dots minigame.

public class Line : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    public Rigidbody2D rbl;

    [HideInInspector] public List<Vector2> points = new List<Vector2>();
    [HideInInspector] public int pointsCount = 0;

    float pointMinDistance = 0.1f;
    float circleColliderRadius;

    public void AddPoint (Vector2 newPoint)
    {
        if (pointsCount >= 1 && Vector2.Distance(newPoint, GetLastPoint()) < pointMinDistance)
            return;

        points.Add(newPoint);
        pointsCount++;

        CircleCollider2D circleCollider = this.gameObject.AddComponent<CircleCollider2D>();
        circleCollider.offset = newPoint;
        circleCollider.radius = circleColliderRadius;

        lineRenderer.positionCount = pointsCount;
        lineRenderer.SetPosition(pointsCount - 1, newPoint);

        if (pointsCount > 1)
            edgeCollider.points = points.ToArray();
    }

    public Vector2 GetLastPoint()
    {
        return (Vector2)lineRenderer.GetPosition(pointsCount - 1);
    }

    public void UsePhysics(bool usePhysics)
    {
        rbl.isKinematic = !usePhysics;
    }

    public void SetLineColor (Gradient colorGradient)
    {
        lineRenderer.colorGradient = colorGradient;
    }

    public void SetPointsMinDistance(float distance)
    {
        pointMinDistance = distance;
    }

    public void SetLineWidth (float width)
    {
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;

        circleColliderRadius = width / 2f;
        edgeCollider.edgeRadius = circleColliderRadius;
    }
}
