using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) {
			this.transform.rotation *= Quaternion.AngleAxis(-5.0f, Vector3.up);
		}

		if (Input.GetKey(KeyCode.D)){
			this.transform.rotation *= Quaternion.AngleAxis(5.0f, Vector3.up);
		}

        if (Input.GetKey(KeyCode.W)){
			this.transform.position += this.transform.localRotation * Vector3.forward/3; 
		}

        if (Input.GetKey(KeyCode.S)){
			this.transform.position += (this.transform.localRotation * Vector3.forward/3)*-1; 
		}
		
    }
}
