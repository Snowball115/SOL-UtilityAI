using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testo : MonoBehaviour
{
    public UtilityScorer scorer;

    void Update()
    {
        scorer.EvaluateScore();
    }
}
