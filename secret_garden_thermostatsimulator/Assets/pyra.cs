using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pyra : MonoBehaviour
{
  // Start is called before the first frame update

	GameObject house;
	Mesh mesh, meshHouse;

	public float interval = 0.5f;
	float nextTime = 0;

	// Punkte der zwei Dreiecke, die ein Rechteck ergeben
	Vector3 a, b, c, d, e, f;

	List<Vector3> vertices;  //Punkte
	List<Vector3> normals;   //Sichtrichtung Vektor
	List<int> faces;         //Dreiecke

	List<Vector3> verticestown;  //Liste fuer house
	List<Vector3> normalstown;
	List<int> facestown;

	int counter = 0;         //Fuer weitere Punkte
	int countertown = 0;

	
	void Start()
     {

		 
		vertices = new List<Vector3>();
		normals = new List<Vector3>();
		faces = new List<int>();

		verticestown = new List<Vector3>();
		normalstown = new List<Vector3>();
		facestown = new List<int>();
	
		//Haus erstellen
		house = new GameObject("house");
		house.AddComponent<MeshFilter>();
		house.AddComponent<MeshRenderer>();
		house.AddComponent<MeshCollider>();   
		meshHouse = house.GetComponent<MeshFilter>().mesh;
		house.AddComponent<Rigidbody>().isKinematic = true;
        

		meshHouse.Clear();
		house.transform.position = new Vector3((75), 20,221);

		//Material des Hauses
		Renderer rend = house.GetComponent<Renderer>();
		rend.material = new Material(Shader.Find("Diffuse"));
		rend.material.color = Color.white;


		if (!meshHouse)
        {
            Debug.LogError("mesh");
            return;
        }
        MeshCollider meshCollider = house.AddComponent<MeshCollider>();
        meshCollider.sharedMesh = meshHouse;

		
		//Haus bauen
		createTown();

		
       

		
		
	}

	//Normale kalkulieren
	Vector3 calcNormal(Vector3 a, Vector3 b, Vector3 c)
	{
		Vector3 ab = b - a;
		Vector3 ac = c - a;

		return Vector3.Cross(ab, ac).normalized;
	}

	//Face ist ein Viereck, das aus zwei Dreiecken besteht. In dieser Funktion wird ein Viereck aus Vier Vektorpunkten erstellt
	void createFace(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
    {
		verticestown.Add(a);
		verticestown.Add(b);
		verticestown.Add(c);
		verticestown.Add(d);

		Vector3 normale = calcNormal(c, b, a);
		Debug.Log(normale);

		normalstown.Add(normale);
		normalstown.Add(normale);
		normalstown.Add(normale);
		normalstown.Add(normale);

		//erstes Dreieck
		facestown.Add(0 + countertown);
		facestown.Add(2 + countertown);
		facestown.Add(1 + countertown);

		//zweites Dreieck
		facestown.Add(0 + countertown);
		facestown.Add(3 + countertown);
		facestown.Add(2 + countertown);

		countertown += 4;
	}

	//In dieser Funktion wird ein Haus erstellt. Dazu werden die Vektorpunkte in einer createFace Funktion verbunden, um die jeweiligen Seiten des Hauses zu bilden
	void createHouse(Vector3 position)
    {
		float hoehe = Random.Range(3.0f, 7.0f);   //Der Y-Wert des Daches variiert von 3-9, damit die Haeuser unterschiedliche Hoehen haben
		Vector3 a = new Vector3(10, 0, 10) + position;
		Vector3 b = new Vector3(-10, 0, 10) + position;
		Vector3 c = new Vector3(-10, 0, -10) + position;
		Vector3 d = new Vector3(10, 0, -10) + position;

		Vector3 e = new Vector3(0, hoehe, 0) + position;
		Vector3 f = new Vector3(0, hoehe, 0) + position;
		Vector3 g = new Vector3(0, hoehe, 0) + position;
		Vector3 h = new Vector3(0, hoehe, 0) + position;

        createFace(a, b, c, d);
        createFace(e, f, g, h);

        //vordere Seite
        createFace(a, b, f, e);

        //linke Seite
        createFace(b, c, g, f);

        //rechte Seite
        createFace(d, a, e, h);

        //Rueckseite
        createFace(c, d, h, g);
	}

    void createHouse1(Vector3 position)
    {
		float hoehe = Random.Range(5.0f, 10.0f);   //Der Y-Wert des Daches variiert von 3-9, damit die Haeuser unterschiedliche Hoehen haben
		Vector3 a = new Vector3(6, 0, 6) + position;
		Vector3 b = new Vector3(-6, 0, 6) + position;
		Vector3 c = new Vector3(-6, 0, -6) + position;
		Vector3 d = new Vector3(6, 0, -6) + position;

		Vector3 e = new Vector3(0, hoehe, 0) + position;
		Vector3 f = new Vector3(0, hoehe, 0) + position;
		Vector3 g = new Vector3(0, hoehe, 0) + position;
		Vector3 h = new Vector3(0, hoehe, 0) + position;

        createFace(a, b, c, d);
        createFace(e, f, g, h);

        //vordere Seite
        createFace(a, b, f, e);

        //linke Seite
        createFace(b, c, g, f);

        //rechte Seite
        createFace(d, a, e, h);

        //Rueckseite
        createFace(c, d, h, g);
	}

	//In dieser Funktion wird die Stadt erstellt. X und Z variieren hier, damit die Haeuser randomisiert an verschiedenen Stellen stehen
	void createTown()
    {
		
		for(int i = -5; i < 5; i = i + 2)
        {
			for(int j = -3; j < 3; j = j + 2)
            {
				Vector3 position = new Vector3((i *Random.Range(-7,7)), 0,(j*Random.Range(-5,8)));
				createHouse(position);
            }
        }

        for(int i = -5; i < 5; i = i + 2)
        {
			for(int j = -3; j < 3; j = j + 2)
            {
				Vector3 position = new Vector3((i *Random.Range(-8,7)), 0,(j*Random.Range(-5,8)));
				createHouse1(position);
            }
        }

		//Mesh townMesh = new Mesh();
		//house.GetComponent<MeshFilter>().mesh = townMesh;
		meshHouse.vertices = verticestown.ToArray();
		meshHouse.normals = normalstown.ToArray();
		meshHouse.triangles = facestown.ToArray();
	}


	

	


	

	
}

