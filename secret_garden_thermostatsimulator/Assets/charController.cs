using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    public Rigidbody rb;

    public bool onGround = true;
    public bool controls = true;
    

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    public GameObject PlayerCam;
    public GameObject ShipCam;
    public GameObject BoatCam;
    //public GameObject player;


    // Update is called once per frame

    void start() {
        PlayerCam.SetActive(true);
        
    }
    void Update()
    {
        if (/*controls == true*/ gameObject.active) {
        float horizontalMovement = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float verticalMovement = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(horizontalMovement, 0, verticalMovement);

        if (Input.GetButtonDown("Jump") && onGround == true)
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            onGround = false;
        } 
        }
       
    }

    private void OnCollisionStay(Collision collision) {
           if(collision.gameObject.tag == "Ground") {
               Debug.Log("Boden Collision!");
               onGround = true;
           }

           if(collision.gameObject.name == "StarSparrow12") {
               Debug.Log("Collision Ship");
               controls = false;
               PlayerCam.SetActive(false);
               ShipCam.SetActive(true);

           }

           if(collision.gameObject.name == "WoodBoat") {
               Debug.Log("Collision Boat");
               PlayerCam.SetActive(false);
               BoatCam.SetActive(true);
               

           }

    /*private void OnCollisionStay(Collision collision) {
            if(collision.gameObject.tag == "Enviroment") {
                Debug.Log("Enviroment Collision!");
                
            }
    }

    private void OnColissionStay(Collision collision) {
           if(collision.gameObject.name == "StarSparrow12") {
               Debug.Log("Collision Ship");
           }
        }*/
}
}
