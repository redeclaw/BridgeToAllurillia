using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/UnitCard")]

public class UnitCardTemp : CardTemp{
    [SerializeField] private int attack;
    [SerializeField] private int health;
    [SerializeField] private List<UnitAbility> abilities;
    public int GetAttack(){
        return attack;
    }
    public int GetHealth(){
        return health;
    }
    public List<UnitAbility> GetAbilities(){
        return abilities;
    }
}
