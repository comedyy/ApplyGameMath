using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotToLineSegment : MonoBehaviour
{
    public Vector3 pointC;
    public Vector3 segmentPointA;
    public Vector3 segmentPointB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(pointC, 1);
        Gizmos.DrawWireSphere(segmentPointA, 1);
        Gizmos.DrawWireSphere(segmentPointB, 1);
        Gizmos.DrawLine(segmentPointB, segmentPointA);

        Gizmos.color = Color.red;
        var p = GetNearestPoint(segmentPointA, segmentPointB, pointC);
        Gizmos.DrawLine(p, pointC);
    }

    private Vector3 GetNearestPoint(Vector3 segmentPointA, Vector3 segmentPointB, Vector3 pointC)
    {
        var BA = segmentPointA - segmentPointB;
        var dot = Vector3.Dot(pointC - segmentPointB, BA);
        var sqrtLength = Vector3.SqrMagnitude(BA);
        var lerp = dot / sqrtLength;
        lerp = Mathf.Clamp01(lerp);

        return Vector3.Lerp(segmentPointB, segmentPointA, lerp);
    }
}
