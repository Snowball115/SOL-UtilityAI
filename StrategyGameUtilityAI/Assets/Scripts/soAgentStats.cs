using UnityEngine;

[CreateAssetMenu(fileName = "New Stats", menuName = "Create new Agent Stats")]
public class soAgentStats : ScriptableObject
{
    // health points
    public float healthPoints;

    // movement speed
    public float moveSpeed;

    // attack power
    public float attackPoints;
}