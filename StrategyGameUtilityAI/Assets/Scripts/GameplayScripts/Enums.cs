using UnityEngine;

/// <summary>
/// All enumerations used in the project
/// </summary>
public class Enums : MonoBehaviour
{
    public enum Teams
    {
        BLUE,
        RED
    }

    public enum AgentRoles
    {
        CIVILIAN,
        SOLDIER
    }

    public enum ResourceType
    {
        WOOD,
        ORE,
        FOOD
    }
}
