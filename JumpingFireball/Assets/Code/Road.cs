using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public Transform PositionTransform;
    public Transform RoadTransform;
    private Vector3 _startPositionScale;
    private Vector3 _startRoadScale;

    public void Init()
    {
        _startPositionScale = PositionTransform.localScale;
        _startRoadScale = RoadTransform.localScale;
    }
    
    public void NewScaleRoad(float i)
    {
        PositionTransform.localScale = _startPositionScale * i;
        Vector3 newScale = _startRoadScale;
        newScale.z *= i;
        RoadTransform.localScale = newScale;
    }
}
