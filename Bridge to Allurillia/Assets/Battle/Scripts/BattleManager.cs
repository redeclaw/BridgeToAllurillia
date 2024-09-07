using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public enum ActionType{
        Rally,
        Swap
    }
    public GameObject test;
    public GameObject ship;
    public GameObject spacer;
    public GameObject shipRow;
    public GameObject shipArea;
    public EnemyInfo enemyInfo;
    public List<ShipInfo> shipInfos;
    public List<ShipAbility> abilities;
    public List<ShipTemplate> tempList;
    public static BattleManager instance;
    public GameObject effectsCanvas;
    public Button endTurnButton;
    public GameObject selectedShip;
    public bool Actionable;
    public ActionType actionType;
    public Button[] buttons;
    public static void TestAbility(){
        instance.test.GetComponent<Ship>().TriggerAbility();
    }
    public int RowCalc(int numShips){
        double result = (math.sqrt(1 + 8 * numShips) - 1) / 2;
        int final = (int)math.ceil(result);
        return final;
    }
    void Awake(){
        if (instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Actionable = true;
        actionType = ActionType.Rally;
        endTurnButton.interactable = true;
        foreach (Button current in buttons){
            current.interactable = true;
        }
        buttons[0].interactable = false;
        shipInfos = new()
        {
            //new ShipInfo(0, 1),
            //new ShipInfo(0, 2),
        };
        shipInfos.Add(new ShipInfo(4, 1));
        shipInfos.Add(new ShipInfo(1, 1));
        shipInfos.Add(new ShipInfo(2, 1));
        shipInfos.Add(new ShipInfo(0, 1));
        shipInfos.Add(new ShipInfo(3, 1));
        shipInfos.Add(new ShipInfo(0, 1));
        for (int i = 0; i < 2; i++){
            //shipInfos.Add(new ShipInfo(2, 1));
        }
        shipInfos.Add(new ShipInfo(5, 1));
        for (int i = 0; i < 2; i++){
            shipInfos.Add(new ShipInfo(1, 1));
        }
        shipInfos.Add(new ShipInfo(5, 1));
        SpawnShips();
    }
    public static IEnumerator EndTurn(){
        instance.endTurnButton.interactable = false;
        instance.Actionable = false;
        foreach(Transform shipRow in instance.shipArea.transform){
            foreach(Transform ship in shipRow){
                if (ship.GetComponent<Ship>()){
                    ship.GetComponent<Ship>().TriggerAbility();
                    yield return new WaitForSeconds(.25f);
                }
            }
        }
        yield return new WaitForSeconds(1);
        while(instance.effectsCanvas.transform.childCount != 0){
            yield return new WaitForSeconds(1);
        }
        yield return new WaitForSeconds(.5f);
        Debug.Log(NumShips());
        instance.enemyInfo.EnemyTurn();
        
    }
    public static void StartTurn(){
        instance.Actionable = true;
        instance.endTurnButton.interactable = true;
    }
    public void SpawnShips(){
        int numRows = RowCalc(shipInfos.Count);
        shipArea.GetComponent<RectTransform>().sizeDelta = new Vector2(1700, numRows * 120);
        for (int i = 0; i < numRows; i++){
            GameObject newRow = Instantiate(shipRow, new Vector2(0, 0), Quaternion.identity);
            newRow.transform.SetParent(shipArea.transform);
            //newRow.GetComponent<GridLayoutGroup>().cellSize = new Vector2(150, 150);
        }
        int counter = 0;
        for (int i = 0; i < numRows; i++){
            for (int j = 0; j < i + 1; j++){
                if (counter >= shipInfos.Count){
                    GameObject Spacer = Instantiate(spacer, new Vector2(0, 0), Quaternion.identity);
                    Spacer.transform.SetParent(shipArea.transform.GetChild(i).transform);
                }
                else{
                    GameObject newship = Instantiate(ship, new Vector2(0, 0), Quaternion.identity);
                    newship.transform.SetParent(shipArea.transform.GetChild(i).transform);
                    newship.GetComponent<Ship>().shipTemplate = tempList[shipInfos[counter].id];
                    counter++;
                }
            }
        }
    }
    public static void ShipDeath(GameObject ship){
        int shipIndex = ship.transform.GetSiblingIndex();
        Debug.Log($"ship index: {shipIndex}");
        int rowIndex = ship.transform.parent.GetSiblingIndex();
        GameObject Spacer = Instantiate(instance.spacer, new Vector2(0, 0), Quaternion.identity);
        Spacer.transform.SetParent(instance.shipArea.transform.GetChild(rowIndex).transform);
        Spacer.transform.SetSiblingIndex(shipIndex);
    }

    //returns num of ships currently in fleet
    public static int NumShips(){
        int count = 0;
        foreach(Transform shipRow in instance.shipArea.transform){
            foreach(Transform ship in shipRow){
                if (ship.GetComponent<Ship>()){
                    count++;
                }
            }
        }
        return count;
    }

    //returns random ship from those currently in fleet
    public static Ship RandShip(){
        int shipnum = UnityEngine.Random.Range(0, NumShips());
        Debug.Log(shipnum);
        int count = 0;
        foreach(Transform shipRow in instance.shipArea.transform){
            foreach(Transform ship in shipRow){
                if (ship.GetComponent<Ship>()){
                    if (count == shipnum){
                        return ship.GetComponent<Ship>();
                    }
                    count++;
                }
            }
        }
        return null;
    }

    public static void TriggerRand(){
        RandShip().TriggerAbility();
    }
    public static void SwapShips(GameObject ship1, GameObject ship2){
        int shipIndex1 = ship1.transform.GetSiblingIndex();
        int shipRow1 = ship1.transform.parent.GetSiblingIndex();
        int shipIndex2 = ship2.transform.GetSiblingIndex();
        int shipRow2 = ship2.transform.parent.GetSiblingIndex();
        ship1.transform.SetParent(instance.shipArea.transform.GetChild(shipRow2));
        ship1.transform.SetSiblingIndex(shipIndex2);
        ship2.transform.SetParent(instance.shipArea.transform.GetChild(shipRow1));
        ship2.transform.SetSiblingIndex(shipIndex1);
    }
    public static void SetAction(int action){
        foreach (Button current in instance.buttons){
            current.interactable = true;
        }
        instance.buttons[action].interactable = false;
        switch(action){
            case 0:
                instance.actionType = ActionType.Rally;
                break;
            case 1:
                instance.actionType = ActionType.Swap;
                break;
        }
    }
    public static void ShipSelected(GameObject ship){
        if (!instance.Actionable){
            return;
        }
        switch (instance.actionType)
        {
            case ActionType.Rally:
                ship.GetComponent<Ship>().TriggerAbility();
                instance.Actionable = false;
                break;
            case ActionType.Swap:
                if (instance.selectedShip == null){
                    instance.selectedShip = ship;
                }
                else{
                    SwapShips(ship, instance.selectedShip);
                    instance.selectedShip = null;
                    instance.Actionable = false;
                }
                break;
        }
    }


}
