using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class messages : MonoBehaviour
{

    public GameObject ship;
    public GameObject sauce;
    public GameObject pasta;
    public GameObject herbs;
    string text = "";
    
    void start() {
        sauce.SetActive(true);
        
    }

    void OnGUI() {
        if (sauce.activeSelf == true) {
        GUI.Label(new Rect(20, 20, 200, 200), "1. Betrete das Raumschiff und finde die Sauce im Planetenfeld!");
        }
        if (pasta.activeSelf == true) {
        GUI.Label(new Rect(20, 20, 200, 200), "2. Lande auf dem roten Landefeld und suche im Labyrinth nach der Pasta!"); 
        }
        if (herbs.activeSelf == true) {
        GUI.Label(new Rect(20, 20, 200, 200), "3. Verlasse das Labyrinth, überwinde die Hindernisse und finde die Kräuter in den Bergen"); 
        }
    }
    
}
