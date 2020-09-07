using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		float verticalMovement = Input.GetAxis("Vertical") * Time.deltaTime * speed;

		transform.Translate(horizontalMovement, 0, verticalMovement);
    }
}
