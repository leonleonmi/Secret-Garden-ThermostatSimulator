using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mysticForestCollider : MonoBehaviour
{

    public AudioSource forest;
    // Start is called before the first frame update
    void Start()
    {
        forest = GetComponent<AudioSource>();
        GetComponent<AudioSource> ().playOnAwake = false;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision) {
           if(collision.gameObject.name == "PlayerOne") {
               forest.Play();
           }
    
}
    private void OnCollisionExit(Collision collision) {
           if(collision.gameObject.name == "PlayerOne") {
               forest.Stop();
           }
}
}

