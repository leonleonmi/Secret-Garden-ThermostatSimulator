using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ending : MonoBehaviour
{

    public GameObject trigger;
    public GameObject sauce;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        trigger.SetActive(false);
    }

    // Update is called once per frame
    
    private void OnCollisionStay(Collision collision) {
        if (collision.gameObject.name == "PlayerOne" && sauce.active == false) {
            trigger.SetActive(true);
            player.SetActive(false);
        }
    }
}
