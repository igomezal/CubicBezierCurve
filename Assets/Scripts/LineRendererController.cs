using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererController : MonoBehaviour
{

    private LineRenderer lineRenderer;
    private Transform[] points;
    
    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.material.renderQueue = 0;
    }

    public void SetPoints(Transform[] points)
    {
        this.points = points;
        lineRenderer.positionCount = points.Length;
        lineRenderer.enabled = true;
    }

    void Update()
    {
        for (var index = 0; index < points.Length; index++)
        {
            lineRenderer.SetPosition(index, points[index].position);
        }
    }
}
