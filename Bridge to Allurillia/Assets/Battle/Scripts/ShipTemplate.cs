using UnityEngine;

[CreateAssetMenu(fileName = "New Ship", menuName = "Ships/Ship")]


public class ShipTemplate : ScriptableObject
{
    public int id;
    public string shipName;
    public int health;
    public ShipAbility ability;
    public Sprite sprite;
}