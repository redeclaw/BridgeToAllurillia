using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShipDisplay : MonoBehaviour
{
    public Ship ship;
    public TextMeshProUGUI nameText;
    public Image shipImage;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI shieldText;
    public TextMeshProUGUI abilityText;
    // Start is called before the first frame update
    void Start()
    {
        nameText.text = ship.shipName;
        shipImage.sprite = ship.shipImage.sprite;
        healthText.text = ship.health.ToString();
        shieldText.text = ship.shield.ToString();
        abilityText.text = ship.ability.FullDescription();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
