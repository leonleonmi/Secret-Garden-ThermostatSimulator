using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parmesan : MonoBehaviour
{

    public GameObject parm;
    // Start is called before the first frame update
    void Start()
    {
        parm.SetActive(false);
    }



    private void OnCollisionStay(Collision collision) {
           if(collision.gameObject.name == "PlayerOne") {
               Debug.Log("Parmesan collected!");
               parm.SetActive(false);
           }

}
}
