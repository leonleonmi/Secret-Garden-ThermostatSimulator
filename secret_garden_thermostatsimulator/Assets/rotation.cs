using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{

    public GameObject pasta;
    public GameObject sauce;
    public GameObject herbs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pasta.transform.Rotate(0, 1.5f, 0);
        sauce.transform.Rotate(0, 1.5f, 0);
        herbs.transform.Rotate(0, 1.5f, 0);
    }
}
