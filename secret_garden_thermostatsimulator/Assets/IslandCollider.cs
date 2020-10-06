using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandCollider : MonoBehaviour
{

    public GameObject PlayerCam;
    public GameObject BoatCam;
    public GameObject Player;
    public GameObject Boat;

    
    // Start is called before the first frame update
    void start()
    {
        
    }
    private void OnCollisionStay(Collision collision) {
        if(collision.gameObject.name == "Boot"); {
               Debug.Log("Island Entered!");
               Player.SetActive(true);
               Player.transform.position = new Vector3(11, 23, -21);
               BoatCam.SetActive(false);
               Boat.SetActive(false);
               PlayerCam.SetActive(true);
           }
    }
}
