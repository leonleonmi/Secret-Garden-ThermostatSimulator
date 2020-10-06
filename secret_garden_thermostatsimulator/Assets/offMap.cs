using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class offMap : MonoBehaviour
{

    public GameObject player;
    public GameObject sauce;
    public GameObject pasta;
    public GameObject herbs;
    public GameObject parm;

    // Start is called before the first frame update
    
    private void OnCollisionStay(Collision collision) {
        if (collision.gameObject.name == "PlayerOne") {
            Debug.Log("Runtergefallen!");
            if (sauce.activeSelf == true) {
                player.transform.position = new Vector3(143.0f, 22.0f, -183.0f);
            }
            if (pasta.activeSelf == true) {
                player.transform.position = new Vector3(5.0f, 22.0f, -24.0f);
            }
            if (herbs.activeSelf == true) {
                player.transform.position = new Vector3(4.0f, 22.0f, 26.0f);
            }
            if (parm.activeSelf == true) {
                player.transform.position = new Vector3(9.0f, 22.0f, 125.0f);
            }
            if (sauce.activeSelf == false && pasta.activeSelf == false && herbs.activeSelf == false && parm.activeSelf == false) {
                player.transform.position = new Vector3(146.0f, 22.0f, 155.0f);
                player.transform.Rotate(0, 180, 0);
            }
        }

    }
}
