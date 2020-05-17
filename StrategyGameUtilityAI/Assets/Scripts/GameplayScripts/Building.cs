using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Player _PlayerOwner;

    public Enums.Teams _PlayerTeam;

    public float _LifePoints;


    void Start()
    {
        _PlayerTeam = _PlayerOwner._PlayerTeam;
    }
}
