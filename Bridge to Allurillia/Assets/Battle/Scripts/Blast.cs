using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Blast", menuName = "Abilities/Blast")]

public class Blast : ShipAbility
{
    public int strength;
    public int frequency;
    public global::Laser.LaserType laserType;
    public int rotation;
    public override string AbilityDescription(){
        if (laserType == Laser.LaserType.allyDmg){
            return $"fire {frequency} lasers, dealing {strength} damage each";
        }
        else if (laserType == Laser.LaserType.allyHelp){
            return $"fire {frequency} lasers to the left and right, shielding ships for {strength} each";
        }
        else{
            return "error";
        }
    }
    public override int Id => 0;
    public GameObject laser;
}
