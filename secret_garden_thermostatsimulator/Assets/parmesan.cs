using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parmesan : MonoBehaviour
{

    public GameObject parm;
    public AudioSource collect;
    // Start is called before the first frame update
    void Start()
    {
        collect = GetComponent<AudioSource>();
        parm.SetActive(false);
        
    }



    private void OnCollisionStay(Collision collision) {
           if(collision.gameObject.name == "PlayerOne") {
               collect.Play();
               Debug.Log("Parmesan collected!");
               parm.SetActive(false);
           }

}
}
