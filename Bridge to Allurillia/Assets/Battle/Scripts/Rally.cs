using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Rally", menuName = "Abilities/Rally")]

public class Rally : ShipAbility
{
    public int frequency;
    public override string AbilityDescription(){
        return $"trigger the end of turn abilities of {frequency} ships";
    }
    public override int Id => 3;
}
