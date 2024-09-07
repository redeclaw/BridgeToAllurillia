using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FieldSpellCard : MonoBehaviour
{
    public SpellCard workingCard;
    public Image cardImage;
    public TextMeshProUGUI cardTitle;
    public Transform starArea;
    // Start is called before the first frame update
    void Start()
    {
        cardImage.sprite = workingCard.GetCardSprite();
        cardTitle.text = workingCard.GetTitle();        
    }

    public void OnClick(){
        Debug.Log("spell clicked!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
