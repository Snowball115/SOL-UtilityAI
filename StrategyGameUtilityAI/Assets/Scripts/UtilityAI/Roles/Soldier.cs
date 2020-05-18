using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : UtilityAgent
{
    // Animation curves
    [Header("---- Curves ----")]
    public soAnimationCurve _HealthCurve;


    protected override void Start()
    {
        base.Start();
    }
}
