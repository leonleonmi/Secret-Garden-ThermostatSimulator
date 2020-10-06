using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class berge : MonoBehaviour
{
  // Start is called before the first frame update

	GameObject mountain;
	Mesh mesh, meshmountain;
	Vector3 a, b, c, d, e, f;

	List<Vector3> vertices;
	List<Vector3> normals;
	List<int> faces;
	List<Vector3> verticesmountains;
	List<Vector3> normalsmountains;
	List<int> facesmountains;

	int counter = 0;         
	int countermountains = 0;

	
	void Start()
     {
		vertices = new List<Vector3>();
		normals = new List<Vector3>();
		faces = new List<int>();

		verticesmountains = new List<Vector3>();
		normalsmountains = new List<Vector3>();
		facesmountains = new List<int>();
	
		mountain = new GameObject("mountain");
		mountain.AddComponent<MeshFilter>();
		mountain.AddComponent<MeshRenderer>();
		mountain.AddComponent<MeshCollider>();   
		meshmountain = mountain.GetComponent<MeshFilter>().mesh;
		mountain.AddComponent<Rigidbody>().isKinematic = true;
        meshmountain.Clear();

		mountain.transform.position = new Vector3((75), 20,221);

		//Material 
		Renderer rend = mountain.GetComponent<Renderer>();
		rend.material = new Material(Shader.Find("Diffuse"));
		rend.material.color = Color.black;
		
		if (!meshmountain)
        {
            Debug.LogError("mesh");
            return;
        }
        MeshCollider meshCollider = mountain.AddComponent<MeshCollider>();
        meshCollider.sharedMesh = meshmountain;

		createMountains();

	}

	
	Vector3 calcNormal(Vector3 a, Vector3 b, Vector3 c)
	{
		Vector3 ab = b - a;
		Vector3 ac = c - a;

		return Vector3.Cross(ab, ac).normalized;
	}

	
	void createFace(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
    {
		verticesmountains.Add(a);
		verticesmountains.Add(b);
		verticesmountains.Add(c);
		verticesmountains.Add(d);

		Vector3 normale = calcNormal(c, b, a);
		Debug.Log(normale);

		normalsmountains.Add(normale);
		normalsmountains.Add(normale);
		normalsmountains.Add(normale);
		normalsmountains.Add(normale);

		
		facesmountains.Add(0 + countermountains);
		facesmountains.Add(2 + countermountains);
		facesmountains.Add(1 + countermountains);

		
		facesmountains.Add(0 + countermountains);
		facesmountains.Add(3 + countermountains);
		facesmountains.Add(2 + countermountains);

		countermountains += 4;
	}

	//Berg wird erstellt
	void createmountain(Vector3 position)
    {
		//Höhe Berge variieren
		float hoehe = Random.Range(3.0f, 7.0f);
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

        createFace(a, b, f, e);
		createFace(b, c, g, f);
		createFace(d, a, e, h);
		createFace(c, d, h, g);
	}

    void createmountain1(Vector3 position)
    {
		float hoehe = Random.Range(5.0f, 10.0f);
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

        
        createFace(a, b, f, e);
		createFace(b, c, g, f);
		createFace(d, a, e, h);
		createFace(c, d, h, g);
	}

	//Alpen werden erstellt und variieren random in ihren Positionen
	void createMountains()
    {
		for(int i = -5; i < 5; i = i + 2)
        {
			for(int j = -3; j < 3; j = j + 2)
            {
				Vector3 position = new Vector3((i *Random.Range(-7,7)), 0,(j*Random.Range(-5,8)));
				createmountain(position);
            }
        }

        for(int i = -5; i < 5; i = i + 2)
        {
			for(int j = -3; j < 3; j = j + 2)
            {
				Vector3 position = new Vector3((i *Random.Range(-8,7)), 0,(j*Random.Range(-5,8)));
				createmountain1(position);
            }
        }

		//Mesh townMesh = new Mesh();
		//mountain.GetComponent<MeshFilter>().mesh = townMesh;
		meshmountain.vertices = verticesmountains.ToArray();
		meshmountain.normals = normalsmountains.ToArray();
		meshmountain.triangles = facesmountains.ToArray();
	}


	

	


	

	
}

