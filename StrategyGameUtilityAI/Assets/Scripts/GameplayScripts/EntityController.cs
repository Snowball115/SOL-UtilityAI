using UnityEngine;

/// <summary>
/// Entity class (e.g. Tree, Ore or Field)
/// </summary>
public class EntityController : MonoBehaviour
{
    // The resource type you'll get from this entity
    public Enums.ResourceType _ResourceType;

    // How many resources can be farmed from this entity
    [SerializeField] private int resourcePoints;


    // Entity getting mined
    public ResourceBase GetMined()
    {
        ResourceBase resource = new ResourceBase();
        resource._Type = _ResourceType;

        if (resourcePoints <= 0) DestroyEntity();

        resourcePoints -= 1;

        return resource;
    }

    // Destroy entity if no resource points left
    private void DestroyEntity()
    {
        Destroy(this.gameObject);
    }
}
