using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saucelocation : MonoBehaviour
{

    public GameObject sauce;
    public GameObject pasta;
    // Start is called before the first frame update
    void Start()
    {
        sauce.SetActive(true);
        this.transform.position = new Vector3(Random.Range(-520.0f, 75.0f), Random.Range(-20.0f, 230.0f), Random.Range(-30.0f, -450.0f));
    }

    private void OnCollisionStay(Collision collision) {
           if(collision.gameObject.name == "StarSparrow12") {
               Debug.Log("Sauce collected!");
               sauce.SetActive(false);
               pasta.SetActive(true);
           }
    
}
}
