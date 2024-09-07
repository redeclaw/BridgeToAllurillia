using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipZoom : MonoBehaviour
{
    public GameObject effectsCanvas;
    public Ship ship;
    public GameObject shipDisplay;
    public GameObject shipdisplay;
    // Start is called before the first frame update
    void Start()
    {
        effectsCanvas = GameObject.Find("EffectsCanvas");
    }

    public void OnHoverEnter(){
        shipdisplay = Instantiate(shipDisplay, new Vector2(this.transform.position.x - 200, this.transform.position.y), Quaternion.identity);
        shipdisplay.GetComponent<ShipDisplay>().ship = ship;
        shipdisplay.transform.SetParent(effectsCanvas.transform);
    }
    public void OnHoverExit(){
        Destroy(shipdisplay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
