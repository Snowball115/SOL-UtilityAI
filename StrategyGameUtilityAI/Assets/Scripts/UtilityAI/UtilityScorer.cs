using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Decision/Consideration factor that influences the Utility Action
/// </summary>
[System.Serializable]
public class UtilityScorer
{
    // The reference value the scorer is looking at
    public UtilityValue _ReferenceValue;

    // The curve the consideration gets influenced with
    public soAnimationCurve _Curve;

    // Score of the consideration (should be between 0 and 1)
    public float _CurrentScore;


    public UtilityScorer(UtilityValue value, soAnimationCurve curve)
    {
        _ReferenceValue = value;
        _Curve = curve;
    }

    // Evaluate utility score based on the given input
    public void EvaluateScore()
    {
        // Update reference value input
        _ReferenceValue.UpdateCurrentValue();

        // Calculate the score based on the animation curve and input value
        _CurrentScore = _Curve.curve.Evaluate(_ReferenceValue._CurrentValue / _ReferenceValue._MaxValue);
    }
}