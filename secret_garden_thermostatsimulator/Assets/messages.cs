using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class messages : MonoBehaviour
{

    public GameObject ship;
    public GameObject sauce;
    public GameObject pasta;
    public GameObject herbs;
    public GameObject parm;

    public GameObject trigger;
    
    void start() {
        sauce.SetActive(true);
        
        
    }

    void OnGUI() {
        if (sauce.activeSelf == true) {
        GUI.Label(new Rect(20, 20, 200, 200), "1. Betrete das Raumschiff und finde die Sauce im Planetenfeld! TIPP: Die Sauce kann aus dem rotierenden Planeten gewonnen werden!");
        }
        if (pasta.activeSelf == true) {
        GUI.Label(new Rect(20, 20, 200, 200), "2. Lande auf dem roten Landefeld neben dem Planetenfeld und suche im Labyrinth nach der Pasta!"); 
        }
        if (herbs.activeSelf == true) {
        GUI.Label(new Rect(20, 20, 200, 200), "3. Verlasse das Labyrinth, überwinde die Hindernisse und finde die Kräuter auf den rutschigen Eisplatformen"); 
        }
        if (parm.activeSelf == true) {
        GUI.Label(new Rect(20, 20, 200, 200), "3. Überwinde die Berge und finde den Parmesan im magischen Wald!"); 
        }
        if (sauce.activeSelf == false && pasta.activeSelf == false && herbs.activeSelf == false && parm.activeSelf == false && trigger.activeSelf == false) {
        GUI.Label(new Rect(20, 20, 200, 200), "4. Nutze das Boot und bringe die Zutaten zur Hütte des Restaurants!");
        }
        if (sauce.activeSelf == false && pasta.activeSelf == false && herbs.activeSelf == false && parm.activeSelf == false && trigger.activeSelf == true) {
        GUI.Label(new Rect(20, 20, 200, 200), "Du hast erfolgreich alle Zutaten abgeliefert!");
        }
    }
    
}
