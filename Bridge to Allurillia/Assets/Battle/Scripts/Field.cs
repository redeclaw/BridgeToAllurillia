using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public enum FieldType{
        heal
    }
    public FieldType fieldType;
    public int strength;
    public bool destroy;

    void Update(){
        if (destroy){
            Destroy(this.gameObject);
        }
    }
}
