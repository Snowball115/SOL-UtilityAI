using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soFloatReference : ScriptableObject
{
    public float f;

    // This causes that we don't have to access "f" every time we use a reference to this class
    // "floatReference.f" --> "floatReference"
    public static implicit operator float (soFloatReference s)
    {
        return s.f;
    }
}