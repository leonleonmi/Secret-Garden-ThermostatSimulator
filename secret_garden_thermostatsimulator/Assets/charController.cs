using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    public Rigidbody rb;

    public bool onGround = true;
    public bool shipCollison = true;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float verticalMovement = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(horizontalMovement, 0, verticalMovement);

        if (Input.GetButtonDown("Jump") && onGround == true)
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            onGround = false;
        } 
       
       
    }

    private void OnCollisionStay(Collision collision) {
           if(collision.gameObject.tag == "Ground") {
               onGround = true;
           }
}

    /*private void OnColissionEnter(Collision collision) {
           if(collision.gameObject.name == "StarSparrow12") {
               shipCollison = true;
               Debug.Log("Ship entered");
           }
        }*/
}
