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

    // The curve the consideration gets influenced with
    public soAnimationCurve Curve;

    // Score of the consideration (should be between 0 and 1)
    public float CurrentScore;

    // Evaluate utility score by the given inputs
    public void EvaluateScore()
    {
        // Calculate the score by reference to the Animation curve
        CurrentScore = Curve.curve.Evaluate(ReferenceValue.CurrentValue / ReferenceValue.MaxValue);
    }
}