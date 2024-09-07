using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInfo : MonoBehaviour
{
    public int health;
    public GameObject laser;
    public Image enemyImage;
    public Slider healthSlider;
    public GameObject effectsCanvas;
    public void EnemyTurn(){
        StartCoroutine(FireLaser());
    }
    public IEnumerator FireLaser(){
        for (int i = 0; i < 10; i++){
            GameObject newLaser = Instantiate(laser, this.transform.position, Quaternion.identity);
            newLaser.transform.SetParent(effectsCanvas.transform);
            Laser lasercomp = newLaser.GetComponent<Laser>();
            lasercomp.laserType = Laser.LaserType.enemyDmg;
            lasercomp.strength = 1;
            lasercomp.rotation = Random.Range(240, 300);
            lasercomp.sourceShip = this.gameObject;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1);
        while (effectsCanvas.transform.childCount != 0){
            yield return new WaitForSeconds(1);
        }
        yield return new WaitForSeconds(.5f);
        BattleManager.StartTurn();
    }
    private void OnCollisionEnter2D(Collision2D collision){
        Laser laser = collision.collider.gameObject.GetComponent<Laser>();
        ReceiveDamage(laser.strength);
        
    }
    public void ReceiveDamage(int damage){
        StartCoroutine(TempColor(Color.red));
        health -= damage;
        UpdateSlider();
        if (health < damage){
            Death();
        }
    }
    public void Death(){

    }
    public IEnumerator TempColor(Color color){
        enemyImage.color = color;
        yield return new WaitForSeconds(0.25f);
        enemyImage.color = Color.white;
    }

    public void UpdateSlider(){
        healthSlider.value = health;
    }
    // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue = health;
        UpdateSlider();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
