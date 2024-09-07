using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FieldUnitCard : MonoBehaviour
{
    public UnitCard workingCard;
    public Image cardImage;
    public TextMeshProUGUI cardTitle;
    public TextMeshProUGUI strengthDisplay;
    public TextMeshProUGUI armorDisplay;
    public Transform starArea;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(workingCard.GetTitle());
        cardImage.sprite = workingCard.GetCardSprite();
        cardTitle.text = workingCard.GetTitle();
        Debug.Log(workingCard.GetAttack().ToString());
        strengthDisplay.text = workingCard.GetAttack().ToString();
        armorDisplay.text = workingCard.GetHealth().ToString();
    }

    public void OnClick(){
        Debug.Log("unit clicked!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
