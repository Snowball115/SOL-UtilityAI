using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soFloatReference : ScriptableObject
{
    public float f;

    public static implicit operator float (soFloatReference s)
    {
        return s.f;
    }
}