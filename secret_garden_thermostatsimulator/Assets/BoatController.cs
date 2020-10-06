using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class BoatController : MonoBehaviour
{
  
    public Vector3 startPos;
    public Vector3 newPos;

    //public float speed;
    
    public GameObject BoatCam;
    public GameObject player;





    // Start is called before the first frame update
    void Start()
    {
       
        
        startPos = transform.position;
        newPos = startPos;
        /*
        void Awake()
        {
            ParticleSystem = GetComponentInChildren<ParticleSystem>();
            Rigidbody = GetComponent<Rigidbody>();
            StartRotation = boat.localRotation;
            Camera = Camera.main;
        }*/

    }

    // Update is called once per frame
    void Update()
    {

        if (BoatCam.active == true) {
            player.SetActive(false);
        

        if (Input.GetKeyDown(KeyCode.A))
        {
            newPos.x = newPos.x + 5;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            newPos.z = newPos.z + 5;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            newPos.z = newPos.z - 5;
            Debug.Log("vorne");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            newPos.x = newPos.x - 5;
        }

        transform.position = newPos;
        }
    }


    /*
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Spieler")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //name -Name der Szene, wo soll gestartet werden?
        }
    }
    */
}
