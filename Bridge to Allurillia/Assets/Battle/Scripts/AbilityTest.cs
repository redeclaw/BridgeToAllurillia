using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityTest : MonoBehaviour
{
    public ShipAbility testAbility;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"This Ability's name is {testAbility.GetType().Name}");
        //testAbility.TriggerAbility();
    }

    public void OnClick(){
        //testAbility.TriggerAbility();
    }

    // Update is called once per frame
    void Update()
    {
        //testAbility.TriggerAbility();
    }
}
