using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garden : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Plane); 
        ground.transform.localScale += new Vector3(2, 2, 2);

        GameObject house = GameObject.CreatePrimitive(PrimitiveType.Cube);
        house.transform.localScale += new Vector3(2, 2, 2);
        house.transform.position += new Vector3(12, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
