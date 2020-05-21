using UnityEngine;

[CreateAssetMenu(menuName = "Agent Stats")]
public class soAgentStatsTemplate : ScriptableObject
{
    // health
    public float HealthPoints;

    // attack power
    public float AttackPoints;

    // attack range
    public float AttackRange;

    // movement speed
    public float MoveSpeed;

    // food
    public float FoodPoints;

    // energy
    public float EnergyPoints;
}