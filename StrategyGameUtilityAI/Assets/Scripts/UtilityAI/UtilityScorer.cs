using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Decision/Consideration factor that influences the Utility Action
/// </summary>
[CreateAssetMenu(fileName = "New Uility Scorer", menuName = "Utility AI/Utility Scorer")]
public class UtilityScorer : ScriptableObject
{
    // The reference value the scorer is looking at
    public UtilityValue _ReferenceValue;

    // The curve the consideration gets influenced with
    public soAnimationCurve _Curve;

    // Score of the consideration (should be between 0 and 1)
    public float _CurrentScore;


    // Evaluate utility score by the given inputs
    public void EvaluateScore()
    {
        // Update reference value input
        _ReferenceValue.UpdateCurrentValue();

        // Calculate the score by reference to the Animation curve
        _CurrentScore = _Curve.curve.Evaluate(_ReferenceValue._CurrentValue / _ReferenceValue._MaxValue);
    }
}