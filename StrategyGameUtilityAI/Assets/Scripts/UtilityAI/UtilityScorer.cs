using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Decision/Consideration factor that influences the Utility Action
/// </summary>
[CreateAssetMenu(fileName = "New Uility Scorer", menuName = "Utility AI/Utility Scorer")]
public class UtilityScorer : ScriptableObject
{
    // The reference value it is looking at
    public UtilityValue ReferenceValue;

    // Score of the consideration (should be between 0 and 1)
    public float CurrentScore;

    // The curve the consideration gets influenced with
    public soAnimationCurve Curve;


    // Evaluate utility score by the given inputs
    public void EvaluateScore()
    {
        
    }
}