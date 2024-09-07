using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerAbility : MonoBehaviour
{
    public Ship ship;
    public GameObject effectsCanvas;

    void Start()
    {
        effectsCanvas = GameObject.Find("EffectsCanvas");
    }
    public void AbilityTrigger()
    {
        switch (ship.ability.reqParam){
            case 0:
            break;
            case 1:
            if (ship.shield < ship.ability.reqAmt){
                return;
            }
            else{
                ship.shield -= ship.ability.reqAmt;
                break;
            }
        }
        switch (ship.ability.Id)
        {
            case 0:
                StartCoroutine(Blast((Blast)ship.ability));
                /*Blast temp = (Blast)ship.ability;
                for (int i = 0; i < temp.frequency; i++){
                    GameObject Laser = Instantiate(temp.laser, this.gameObject.transform.position, quaternion.identity);
                    Laser.transform.SetParent(this.transform);
                }*/
                break;
            case 1:
                StartCoroutine(CreateField((CreateField)ship.ability));
                break;
            case 2:
                Defend((Defend)ship.ability);
                break;
            case 3:
                TriggerRandShip((Rally)ship.ability);
                break;
            default:
                break;
        }
    }

    public IEnumerator Blast(Blast blast){
        for(int i = 0; i < blast.frequency; i++){
            GameObject Laser = Instantiate(blast.laser, this.gameObject.transform.position, quaternion.identity);
            Laser laser = Laser.GetComponent<Laser>();
            laser.sourceShip = this.gameObject;
            laser.laserType = blast.laserType;
            laser.strength = blast.strength;
            laser.rotation = blast.rotation;
            Laser.transform.SetParent(effectsCanvas.transform);
            if (blast.laserType == global::Laser.LaserType.allyHelp){
                Laser = Instantiate(blast.laser, this.gameObject.transform.position, quaternion.identity);
                laser = Laser.GetComponent<Laser>();
                laser.sourceShip = this.gameObject;
                laser.laserType = blast.laserType;
                laser.strength = blast.strength;
                laser.rotation = blast.rotation;
                laser.flipRotation = true;
                Laser.transform.SetParent(effectsCanvas.transform);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    public IEnumerator CreateField(CreateField field){
        GameObject newField = Instantiate(field.field, this.gameObject.transform.position, Quaternion.identity);
        newField.transform.SetParent(effectsCanvas.transform);
        newField.GetComponent<Field>().strength = field.strength;
        newField.GetComponent<Field>().fieldType = field.fieldType;
        yield return new WaitForSeconds(10);
        Destroy(newField);
    }

    public void Defend(Defend defend){
        ship.GainShield(defend.strength);
    }

    public void TriggerRandShip(Rally rally){
        for (int i = 0; i < rally.frequency; i++){
            BattleManager.TriggerRand();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
