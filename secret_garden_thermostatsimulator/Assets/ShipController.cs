using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float forward = 35f;
    public float side = 7.5f; 
    public float hover = 2f;

    private float getforward; 
    private float getside;
    private float gethover;
    
    private float forwardSpeedUp = 3f; 
    private float sideSpeedUp = 2f; 
    private float hoverSpeeedUp = 2f;

    public float rotateSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance;

    private float roll;
    public float rollingSpeed = 91f;
    public float rollingSpeedUp = 4f;

    public bool contact = false;
    public GameObject ShipCam;
    public GameObject PlayerOne;

    // Start is called before the first frame update
    void Start()
    {
        screenCenter.x = Screen.width * .5f;
        screenCenter.y = Screen.height * .5f;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        if (ShipCam.active == true) {
        PlayerOne.SetActive(false);
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.x;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;
        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 10f);
        roll = Mathf.Lerp(roll, Input.GetAxisRaw("Roll"), rollingSpeedUp * Time.deltaTime);
        transform.Rotate(-mouseDistance.y * rotateSpeed * Time.deltaTime, mouseDistance.x * rotateSpeed * Time.deltaTime, roll * rollingSpeed * Time.deltaTime, Space.Self); 

        getforward = Mathf.Lerp(getforward, Input.GetAxisRaw("Vertical") * forward, forwardSpeedUp * Time.deltaTime);
        getside = Mathf.Lerp(getside, Input.GetAxisRaw("Horizontal") * side, sideSpeedUp * Time.deltaTime);
        gethover = Mathf.Lerp(gethover, Input.GetAxisRaw("Hover") * hover, hoverSpeeedUp * Time.deltaTime);

        transform.position += transform.forward * getforward * Time.deltaTime;
        transform.position += transform.right * getside * Time.deltaTime;
        transform.position += transform.up * gethover * Time.deltaTime;
    
    }
    }

    /*private void OnColissionEnter(Collision collision) {
           if(collision.gameObject.name == "LandingArea") {
              Debug.Log("Landed!");
              //PlayerOne.SetActive(true);
              
           }
        }*/
}
