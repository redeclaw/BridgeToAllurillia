using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Laser : MonoBehaviour
{
    public enum LaserType{
        allyDmg,
        allyHelp,
        enemyDmg,
    }
    public GameObject sourceShip;
    public LaserType laserType;
    public Image laserImage;
    public int speed;
    public int strength;

    //stored in degrees, have to convert to radians later
    public float rotation;
    //if true, alter rotation so laser goes left instead
    public bool flipRotation;
    public Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(this.GetComponent<BoxCollider2D>(), sourceShip.GetComponent<BoxCollider2D>()); 
        if (laserType == LaserType.allyDmg){
            rotation =  UnityEngine.Random.Range(85, 95);
            laserImage.sprite = sprites[0];
        }
        else if (laserType == LaserType.allyHelp){
            gameObject.layer = 11;
            if (flipRotation){
                rotation = 180 - rotation;
            }
            laserImage.sprite = sprites[1];
        }
        else if (laserType == LaserType.enemyDmg){
            gameObject.layer = 12;
            laserImage.sprite = sprites[2];
        }
        transform.Rotate(0, 0, rotation - 90);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        //Debug.Log("colliding!");
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (laserType == LaserType.allyDmg){
            this.transform.position += new Vector3 (0, speed, 0) * Time.deltaTime;
        }
        else if (laserType == LaserType.allyHelp){
            this.transform.position += new Vector3(speed / 2, speed, 0) * Time.deltaTime;
        }
        else if (laserType == LaserType.enemyDmg){
            this.transform.position -= new Vector3(speed * math.cos(ToRadians(rotation)), speed * math.sin(ToRadians(rotation)), 0) * Time.deltaTime;
        }*/
        this.transform.position += new Vector3(speed * math.cos(ToRadians(rotation)), speed * math.sin(ToRadians(rotation)), 0) * Time.deltaTime;
    }

    float ToRadians(float degrees){
        //Debug.Log((degrees * math.PI)/180);
        return (degrees * math.PI)/180;
    }

}
