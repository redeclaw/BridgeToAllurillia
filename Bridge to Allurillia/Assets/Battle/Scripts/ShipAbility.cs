using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ShipAbility : ScriptableObject
{
    //public abstract string Name { get; }
    public abstract int Id { get; }
    public int reqParam;
    public int reqAmt;
    public string ReqDescription(){
        return reqParam switch
        {
            0 => "End Turn:\n",
            1 => $"End Turn:\nConsumes {reqAmt} shield to ",
            _ => "Error",
        };
    }
    public abstract string AbilityDescription();
    public string FullDescription(){
        string abilDesc = AbilityDescription();
        string reqDesc = ReqDescription();
        if (reqParam == 0){
            abilDesc = char.ToUpper(abilDesc[0]) + abilDesc[1..];
        }
        return reqDesc + abilDesc;
    }
    //public abstract void TriggerAbility();
}
