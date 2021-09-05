using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CubicBeziers : MonoBehaviour
{

    [SerializeField] private Transform[] points;
    [SerializeField] private LineRendererController lineRendererController;
    [SerializeField] private GameObject yellowDotPrefab;
    [SerializeField] private int interpolationFramesCount = 720; // Number of frames to completely interpolate between the 2 positions

    private List<GameObject> cubicBezierCurveDots = new List<GameObject>();
    private int elapsedFrames = 0;
    
    void Start()
    {
        lineRendererController.SetPoints(points);
    }

    private void Update()
    {
        if (elapsedFrames <= interpolationFramesCount)
        {
            float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;
            
            cubicBezierCurveDots.Add(Instantiate(yellowDotPrefab, GetPointInCubicBezierCurve(interpolationRatio), Quaternion.identity));
            
            elapsedFrames = (elapsedFrames + 1);  // reset elapsedFrames to zero after it reached (interpolationFramesCount + 1)
        }
    }

    Vector3 GetPointInCubicBezierCurve(float t)
    {
        if (points.Length == 4)
        {
            var A = points[0].position * (math.pow(-t, 3) + 3 * math.pow(t, 2) - 3 * t + 1);
            var B = points[1].position * (3 * math.pow(t, 3) - 6 * math.pow(t, 2) + 3 * t);
            var C = points[2].position * (-3 * math.pow(t, 3) + 3 * math.pow(t, 2));
            var D = points[3].position * (math.pow(t, 3));

            return A + B + C + D;
        }
        return Vector3.zero;
    }
}
