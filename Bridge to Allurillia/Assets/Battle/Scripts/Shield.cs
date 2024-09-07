using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Shield", menuName = "Abilities/Shield")]

public class Shield : ShipAbility
{
    public int strength;
    public int frequency;
    public override int Id => 1;
    public override string AbilityDescription()
    {
        throw new System.NotImplementedException();
    }
    public GameObject laser;
    //public override string Name => "Blast";
    // Start is called before the first frame update
    /*
    public override void TriggerAbility()
    {
        Debug.Log(this.gameObject.transform.position);
        for (int i = 0; i < frequency; i++){
            GameObject Laser = Instantiate(laser, this.gameObject.transform.position, quaternion.identity);
            Laser.transform.SetParent(this.transform);
        }
    }*/
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
