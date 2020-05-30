using UnityEngine;

/// <summary>
/// Entity class (e.g. Tree, Ore or Field)
/// </summary>
public class EntityController : MonoBehaviour
{
    // The resource type you'll get from this entity
    public Enums.ResourceType _ResourceType;

    // How many resources can be farmed from this entity
    public int _ResourcePoints;


    // Entity getting mined
    public ResourceBase GetMined()
    {
        ResourceBase resource = new ResourceBase();
        resource._Type = _ResourceType;

        if (_ResourcePoints <= 0) DestroyEntity();

        _ResourcePoints -= 1;

        return resource;
    }

    // Destroy entity if no resource points left
    private void DestroyEntity()
    {
        Destroy(this.gameObject);
    }
}
