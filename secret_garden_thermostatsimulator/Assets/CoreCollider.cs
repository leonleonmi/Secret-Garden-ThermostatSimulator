using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreCollider : MonoBehaviour
{
    private void OnColissionEnter(Collision collision) {
           if(collision.gameObject.name == "LandingArea") {
              Debug.Log("Landed!");
           }
        }
}
