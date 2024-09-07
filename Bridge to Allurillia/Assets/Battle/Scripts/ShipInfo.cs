using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInfo
{
    public ShipInfo(){

    }
    public ShipInfo(int id, int health){
        this.id = id;
        this.health = health;
    }
    public int id;
    public int health;
}
