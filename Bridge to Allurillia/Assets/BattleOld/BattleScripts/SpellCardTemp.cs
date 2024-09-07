using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/SpellCard")]

public class SpellCardTemp : CardTemp{
    [SerializeField] private int Ability;
    [SerializeField] private int Potency;
    public int GetAbility(){
        return Ability;
    }
    public int GetPotency(){
        return Potency;
    }
}