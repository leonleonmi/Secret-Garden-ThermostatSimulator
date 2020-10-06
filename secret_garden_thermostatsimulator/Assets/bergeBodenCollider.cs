using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bergeBodenCollider : MonoBehaviour
{

    public AudioSource bells;
    // Start is called before the first frame update
    void Start()
    {
        bells = GetComponent<AudioSource>();
        GetComponent<AudioSource> ().playOnAwake = false;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision) {
           if(collision.gameObject.name == "PlayerOne") {
               bells.Play();
           }
    
}
    private void OnCollisionExit(Collision collision) {
           if(collision.gameObject.name == "PlayerOne") {
               bells.Stop();
           }
}
}
