using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingAreaCollider : MonoBehaviour
{

    public GameObject PlayerCam;
    public GameObject ShipCam;
    public GameObject Player;
    public GameObject Ship;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionStay(Collision collision) {
           if(collision.gameObject.name == "StarSparrow12") {
               Debug.Log("Landed!");
               Player.SetActive(true);
               Player.transform.position = new Vector3(11, 23, -21);
               ShipCam.SetActive(false);
               Ship.SetActive(false);
               PlayerCam.SetActive(true);


           }
}
}
