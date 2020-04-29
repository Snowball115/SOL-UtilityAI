using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Decision factor that influences the Utility Action
/// </summary>
public class UtilityScorer
{
    // Score of the desire
    public float Score;

    // The weight the desire gets scored with (should be usually 1)
    [SerializeField] private float Weight;

    // The curve the desire gets influenced with
    [SerializeField] private soAnimationCurve curve;
}
