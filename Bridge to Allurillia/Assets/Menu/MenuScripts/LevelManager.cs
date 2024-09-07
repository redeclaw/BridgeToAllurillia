using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    
    void Awake()
    {
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else{
            Destroy(gameObject);
            return;
        }
    }

    public static void NewGame(){
        LevelChanger.FadeToLevel(1);
    }

    public static void Continue(){

    }

    public static void Options(){

    }
}
