using UnityEngine;

/// <summary>
/// Building class (e.g. lumberyard or headquarters)
/// </summary>
public class Building : MonoBehaviour
{
    public Player _PlayerOwner;

    public Enums.Teams _PlayerTeam;

    [SerializeField] private float lifePoints;


    void Start()
    {
        _PlayerTeam = _PlayerOwner._PlayerTeam;
    }

    // Retrieve damage
    public void GetDamaged(float damage)
    {
        lifePoints -= damage;

        if (lifePoints <= 0) DestroyBuilding();
    }

    // Destroy building
    private void DestroyBuilding()
    {
        _PlayerOwner._PlayerBuildings.Remove(this.gameObject);
        Destroy(this.gameObject);
    }
}
