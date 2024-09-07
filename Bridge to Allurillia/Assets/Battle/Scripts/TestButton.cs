using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnClick(){
        StartCoroutine(BattleManager.EndTurn());
        //BattleManager.TriggerRand();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
