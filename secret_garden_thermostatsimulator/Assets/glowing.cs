using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glowing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        createGlowing();
    }

    void createGlowing()
    {
		GameObject glow = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        glow.transform.localScale = new Vector3(1, 1, 1);
		glow.name = "glowing";
		//glow.GetComponent<Renderer>().material = brown;
        glow.AddComponent<Rigidbody>().isKinematic = true;

        for (int i = 0; i < 200; i++)
        {
			glow.transform.position = new Vector3(Random.Range(200f, 140f),Random.Range(20, 30f), Random.Range(90f, 150f));
			Instantiate(glow);
        }
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
