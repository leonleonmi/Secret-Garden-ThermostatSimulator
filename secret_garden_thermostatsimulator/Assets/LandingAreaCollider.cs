using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingAreaCollider : MonoBehaviour
{

    public GameObject PlayerCam;
    public GameObject ShipCam;
    public GameObject Player;
    public GameObject Ship;
    public GameObject Sauce;
    public AudioSource crash;
    // Start is called before the first frame update
    void Start()
    {
        crash = GetComponent<AudioSource>();
    }

    private void OnCollisionStay(Collision collision) {
           if(collision.gameObject.name == "StarSparrow12" && Sauce.activeSelf == false) {
               crash.Play();
               Debug.Log("Landed!");
               Player.SetActive(true);
               Player.transform.position = new Vector3(5, 22, -23);
               ShipCam.SetActive(false);
               Ship.SetActive(false);
               PlayerCam.SetActive(true);
           }
}
}
