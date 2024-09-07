using UnityEngine;

public class CardTemp : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private string title;
    [SerializeField] private int cost;
    [SerializeField] private string descText;
    [SerializeField] private Sprite cardSprite;
    public int GetId(){
        return id;
    }
    public string GetTitle(){
        return title;
    }
    public int GetCost(){
        return cost;
    }
    public Sprite GetCardSprite(){
        return cardSprite;
    }
    public string GetDescription(){
        return descText;
    }
}



