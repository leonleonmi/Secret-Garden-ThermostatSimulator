using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{

    public Transform target; 
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    public float rotationSpeed = 20.0f;
    

    void LateUpdate() {


        /*Quaternion camTurnAngle = 
            Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);
            offset = camTurnAngle * offset;*/

        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Slerp(transform.position, desiredPosition, smoothSpeed);


        
        }
    }
    

