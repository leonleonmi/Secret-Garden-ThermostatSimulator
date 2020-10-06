using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pasta : MonoBehaviour
{

    public GameObject nudeln;
    public GameObject herbs;
    public float location;
    public AudioSource collect;
    // Start is called before the first frame update
    void Start()
    {
        collect = GetComponent<AudioSource>();
        nudeln.SetActive(false);
        //herbs.SetActive(false);
        /*location = Random.Range(0.0f, 1.0f);
        if (location <= 0.5f) {
            this.transform.position = new Vector3(-6.0f, 2.5f, 19.0f);
        }
        if (location >= 0.5f) {
            this.transform.position = new Vector3(-6.0f, 2.5f, 39.0f);
        }*/
    }

    // Update is called once per frame
    private void OnCollisionStay(Collision collision) {
           if(collision.gameObject.name == "PlayerOne") {
               collect.Play();
               Debug.Log("Pasta collected!");
               nudeln.SetActive(false);
               herbs.SetActive(true);
           }
    
}
}
