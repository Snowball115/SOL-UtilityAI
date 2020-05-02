using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Uility Value", menuName = "Utility AI/Utility Value (Consideration)")]
public class UtilityValue : ScriptableObject
{
    // Name in editor
    public string Name;

    // The value a desire/consideration has
    public float Value;
}