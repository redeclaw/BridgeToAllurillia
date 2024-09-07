using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Defend", menuName = "Abilities/Defend")]

public class Defend : ShipAbility
{
    public int strength;
    public override string AbilityDescription(){
        return $"shields self for {strength} damage";
    }
    public override int Id => 2;
}
