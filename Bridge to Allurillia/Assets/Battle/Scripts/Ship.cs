using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    public string shipName;
    [SerializeField] TextMeshProUGUI healthDisplay;
    [SerializeField] TextMeshProUGUI shieldDisplay;
    public int baseHealth;
    public int health;
    public int shield;
    public Image shipImage;
    public Image shipBackground;
    public ShipAbility ability;
    public TriggerAbility triggerAbility;
    public ShipTemplate shipTemplate;
    void Start(){
        InitializeFields();
        SetDisplays();
    }
    public void TriggerAbility(){
        StartCoroutine(TempColor(Color.magenta, .5f));
        triggerAbility.AbilityTrigger();
    }
    public void InitializeFields(){
        shipName = shipTemplate.name;
        baseHealth = shipTemplate.health;
        health = shipTemplate.health;
        shield = 0;
        ability = shipTemplate.ability;
        shipImage.sprite = shipTemplate.sprite;
    }
    public void SetDisplays(){
        healthDisplay.text = health.ToString();
        if (health < baseHealth){
            healthDisplay.color = Color.red;
        }
        else if (health == baseHealth){
            healthDisplay.color = Color.white;
        }
        else{
            healthDisplay.color = Color.green;
        }
        shieldDisplay.text = shield.ToString();
    }
    private void OnCollisionEnter2D(Collision2D collision){
        GameObject collidingObject = collision.collider.gameObject;
        if (collidingObject.layer == 17){
            Field field = collidingObject.GetComponent<Field>();
            if (field.fieldType == Field.FieldType.heal){
                HealSelf(field.strength);
            }
        }
        else if (collidingObject.layer == 11 || collidingObject.layer == 12){
            Laser laser = collidingObject.GetComponent<Laser>();
            if (laser.laserType == Laser.LaserType.allyHelp){
                GainShield(laser.strength);
                return;
            }
            else if (laser.laserType == Laser.LaserType.enemyDmg){
                ReceiveDamage(laser.strength);
                //Death();
                return;
            }
        } 
    }
    public void GainShield(int shield){
        StartCoroutine(TempColor(Color.blue));
        this.shield += shield;
        SetDisplays();
    }
    public void ReceiveDamage(int damage){
        StartCoroutine(TempColor(Color.red));
        if (shield >= damage){
            shield -= damage;
            SetDisplays();
            return;
        }
        else{
            health -= (damage - shield);
            SetDisplays();
            if (health <= 0){
                Death();
            }
            return;
        }
    }
    public void HealSelf(int healing){
        if (health >= baseHealth){
            return;
        }
        else{
            health += healing;
            if (health > baseHealth){
                health = baseHealth;
            }
            
        }
        StartCoroutine(TempColor(Color.green));
        SetDisplays();
    }
    public void Death(){
        BattleManager.ShipDeath(this.gameObject);
        Destroy(this.gameObject);
    }
    public IEnumerator TempColor(Color color, float time = 0.5f){
        shipBackground.color = color;
        yield return new WaitForSeconds(time);
        shipBackground.color = Color.clear;
    }
    public void OnClick(){
        BattleManager.ShipSelected(this.gameObject);
    }
}