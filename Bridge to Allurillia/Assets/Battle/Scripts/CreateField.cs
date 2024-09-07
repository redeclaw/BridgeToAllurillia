using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Field", menuName = "Abilities/Field")]

public class CreateField : ShipAbility
{
    public int strength;
    public GameObject field;
    public global::Field.FieldType fieldType;
    public override string AbilityDescription()
    {
        return $"Summons a healing field, healing ally ships for {strength} each";
    }
    public override int Id => 1;
}