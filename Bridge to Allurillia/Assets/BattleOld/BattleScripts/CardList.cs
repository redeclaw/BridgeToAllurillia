using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

[CreateAssetMenu(fileName = "New CardList", menuName = "Cards/CardList")]

public class CardList : ScriptableObject{
    [SerializeField] private List<CardTemp> cards;
    public List<CardTemp> GetCards(){
        return cards;
    }
}
