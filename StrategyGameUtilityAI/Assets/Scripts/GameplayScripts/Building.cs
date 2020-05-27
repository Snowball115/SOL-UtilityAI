using UnityEngine;

/// <summary>
/// Building class (e.g. lumberyard or headquarters)
/// </summary>
public class Building : MonoBehaviour
{
    public Player _PlayerOwner;

    public Enums.Teams _PlayerTeam;

    public float _LifePoints;


    void Start()
    {
        _PlayerTeam = _PlayerOwner._PlayerTeam;
    }

    public void GetDamaged(float damage)
    {
        _LifePoints -= damage;

        if (_LifePoints <= 0) DestroyBuilding();
    }

    private void DestroyBuilding()
    {
        _PlayerOwner._PlayerBuildings.Remove(this.gameObject);
        Destroy(this.gameObject);
    }
}
