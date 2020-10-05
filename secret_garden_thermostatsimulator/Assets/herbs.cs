using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class herbs : MonoBehaviour
{

    public GameObject gewuerze;
    public GameObject parm;
    void Start()
    {
        gewuerze.SetActive(false);
    }

    private void OnCollisionStay(Collision collision) {
           if(collision.gameObject.name == "PlayerOne") {
               Debug.Log("Gewürze collected!");
               gewuerze.SetActive(false);
               parm.SetActive(true);
           }
    
}
}
