using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForTroops : UtilityAction
{
    public WaitForTroops(UtilityAgent agent, float initialScore) : base(agent, initialScore) { }

    public override void Execute()
    {
        base.Enter();
    }
}
