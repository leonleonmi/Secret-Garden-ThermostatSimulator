using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planet : MonoBehaviour
{
    public Material brown;
     
    // Start is called before the first frame update
    void Start()
    {
        createSpheres();
        }

    void createSpheres()
    {
		GameObject planet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        planet.transform.localScale = new Vector3(10, 10, 10);
		planet.name = "planet";
		planet.GetComponent<Renderer>().material = brown;
        planet.AddComponent<Rigidbody>().isKinematic = true;

        for (int i = 0; i < 70; i++)
        {
			planet.transform.position = new Vector3(Random.Range(-500.0f, 70.0f),Random.Range(15.0f, 240.0f), Random.Range(-500.0f, -30.0f));
			Instantiate(planet);
        }
	}

    

   
    // Update is called once per frame
    void Update()
    {
        
    }
}
