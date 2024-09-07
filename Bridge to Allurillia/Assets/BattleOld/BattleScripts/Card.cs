using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;


public class Card
{
    protected int id;
    protected string title;
    protected int cost;
    protected string description;
    protected Sprite cardSprite;
    public Card(){
    }
    public int GetId(){
        return id;
    }
    public string GetTitle(){
        return title;
    }
    public string GetDescription(){
        return description;
    }
    public int GetCost(){
        return cost;
    }
    public Sprite GetCardSprite(){
        return cardSprite;
    }
}

public class UnitCard : Card
{
    private int attack;
    private readonly int BaseAttack;
    private int health;
    private readonly int BaseHealth;
    private readonly List<UnitAbility> abilities;
    public UnitCard(){

    }
    public UnitCard (int id, string title, int cost, string description, Sprite cardSprite, int attack, int health, List<UnitAbility> abilities){
        this.id = id;
        this.title = title;
        this.cost = cost;
        this.description = description;
        this.cardSprite = cardSprite;
        this.attack = attack;
        BaseAttack = attack;
        this.health = health;
        BaseHealth = health;
        this.abilities = abilities;
    }
    public UnitCard (UnitCardTemp template){
        id = template.GetId();
        title = template.GetTitle();
        cost = template.GetCost();
        description = template.GetDescription();
        cardSprite = template.GetCardSprite();
        attack = template.GetAttack();
        BaseAttack = template.GetAttack();
        health = template.GetHealth();
        abilities = template.GetAbilities();
    }
    public int GetAttack(){
        return attack;
    }
    public int GetBaseAttack(){
        return BaseAttack;
    }
    public int GetHealth(){
        return health;
    }
    public int GetBaseHealth(){
        return BaseHealth;
    }
    public List<UnitAbility> GetAbilities(){
        return abilities;
    }
    public void Boost(int boostAmt){
        attack += boostAmt;
    }
    public void Heal(int healAmt){
        if (attack >= BaseAttack){
            return;
        }
        else if (attack + healAmt > BaseAttack){
            attack = BaseAttack;
        }
        else{
            attack += healAmt;
        }
    }
    public void Damage(int dmgAmt){
        if (health > dmgAmt){
            health -= dmgAmt;
        }
        else{
            attack -= dmgAmt - health;
            health = 0;
        }
    }
    public void ApplyShield(int shieldAmt){
        health += shieldAmt;
    }
}

public class SpellCard : Card
{
    public SpellCard(SpellCardTemp template){
        id = template.GetId();
        title = template.GetTitle();
        cost = template.GetCost();
        description = template.GetDescription();
        cardSprite = template.GetCardSprite();
        ability = template.GetAbility();
        potency = template.GetPotency();
    }
    private readonly int ability;
    private int potency;
    public int GetAbility(){
        return ability;
    }
    public int GetPotency(){
        return potency;
    }
    public void SetPotency(int potencyAmt){
        potency = potencyAmt;
    }
}
