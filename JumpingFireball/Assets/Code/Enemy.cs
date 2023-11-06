using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private FinishDetector _finishDetector;

    public void BindFinishDetector(FinishDetector finishDetector) => _finishDetector = finishDetector;
    public void UnBindFinishDetector() => _finishDetector = null;
    private void OnDestroy() => _finishDetector?.MinusObject();
}
