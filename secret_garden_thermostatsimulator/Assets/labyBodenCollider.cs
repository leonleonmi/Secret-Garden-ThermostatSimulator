using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class labyBodenCollider : MonoBehaviour
{

    public AudioSource laby;
    
    void Start()
    {
        laby = GetComponent<AudioSource>();
        GetComponent<AudioSource> ().playOnAwake = false;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision) {
           if(collision.gameObject.name == "PlayerOne") {
               laby.Play();
           }
    
}
    private void OnCollisionExit(Collision collision) {
           if(collision.gameObject.name == "PlayerOne") {
               laby.Stop();
           }
}
}
