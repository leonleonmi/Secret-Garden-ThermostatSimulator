using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceController : MonoBehaviour
{
    public float forward = 35f;
    public float forwardSpeedUp = 20f; 
    public float rotateSpeed = 93f;
    public float rollingSpeed = 91f;
    public float rollingSpeedUp = 4f;
    public float getforward; 
    public float roll;

    public Vector2 middleOfScreen; 
    public Vector2 wayMouse;
    public Vector2 showInput;

    public bool contact = false;
    public GameObject ShipCam;
    public GameObject PlayerOne;

    // Start is called before the first frame update
    void Start()
    {
        middleOfScreen.x = Screen.width * .5f;
        middleOfScreen.y = Screen.height * .5f;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        if (ShipCam.active == true) {
        PlayerOne.SetActive(false);
        showInput.x = Input.mousePosition.x;
        showInput.y = Input.mousePosition.y;

        wayMouse.x = (showInput.x - middleOfScreen.x) / middleOfScreen.x;
        wayMouse.y = (showInput.y - middleOfScreen.y) / middleOfScreen.y;
        wayMouse = Vector2.ClampMagnitude(wayMouse, 10f);

        getforward = Mathf.Lerp(getforward, Input.GetAxisRaw("Vertical") * forward, forwardSpeedUp * Time.deltaTime);
        roll = Mathf.Lerp(roll, Input.GetAxisRaw("Roll"), rollingSpeedUp * Time.deltaTime);
        transform.Rotate(-wayMouse.y * rotateSpeed * Time.deltaTime, wayMouse.x * rotateSpeed * Time.deltaTime, roll * rollingSpeed * Time.deltaTime, Space.Self); 
        transform.position += transform.forward * getforward * Time.deltaTime;
        
    }
    }

}
