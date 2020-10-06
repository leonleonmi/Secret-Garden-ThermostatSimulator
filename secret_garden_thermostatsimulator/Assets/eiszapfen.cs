using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eiszapfen : MonoBehaviour
{

	GameObject icicles;
	Mesh mesh, meshicicles;
	public Material mat;
	

    //Verices
	List<Vector3> vertices;
    List<Vector3> verticesicicles;

    //Normals
	List<Vector3> normals;
    List<Vector3> normalsicicles;

    //Faces
	List<int> faces;
	List<int> facesicicles;

    Vector3 a, b, c, d, e, f; 
	int countericicles = 0;

	 
	 void Start()
     {
		vertices = new List<Vector3>();
        verticesicicles = new List<Vector3>();

		normals = new List<Vector3>();
        normalsicicles = new List<Vector3>();

		faces = new List<int>();
        facesicicles = new List<int>();
	
		icicles = new GameObject("Eiszapfen");
		icicles.AddComponent<MeshFilter>();
		icicles.AddComponent<MeshRenderer>();
		icicles.AddComponent<MeshCollider>();   
		meshicicles = icicles.GetComponent<MeshFilter>().mesh;
		icicles.AddComponent<Rigidbody>().isKinematic = true;
		icicles.GetComponent<Renderer>().material = mat;

        meshicicles.Clear();
		icicles.transform.position = new Vector3(-14.0f, 10.0f, 170.0f);
		icicles.transform.Rotate(0, 90, 0);
		
		Renderer rend = icicles.GetComponent<Renderer>();
		rend.material.color = Color.white;
		
        MeshCollider meshCollider = icicles.AddComponent<MeshCollider>();
        meshCollider.sharedMesh = meshicicles;

		createIciclesField();
	}

	
	Vector3 normale(Vector3 a, Vector3 b, Vector3 c)
	{
		Vector3 ab = b - a;
		Vector3 ac = c - a;

		return Vector3.Cross(ab, ac).normalized;
	}

	
	void createFaces(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
    {
		verticesicicles.Add(a);
		verticesicicles.Add(b);
		verticesicicles.Add(c);
		verticesicicles.Add(d);

		Vector3 normale = this.normale(c, b, a);

		normalsicicles.Add(normale);
		normalsicicles.Add(normale);
		normalsicicles.Add(normale);
		normalsicicles.Add(normale);

		
		facesicicles.Add(0 + countericicles);
		facesicicles.Add(2 + countericicles);
		facesicicles.Add(1 + countericicles);

		facesicicles.Add(0 + countericicles);
		facesicicles.Add(3 + countericicles);
		facesicicles.Add(2 + countericicles);

		countericicles += 4;
	}

	//Berg erstellen
	void createIcicles(Vector3 position)
    {
        
		Vector3 a = new Vector3(Random.Range(4.0f, 10.0f), 0, Random.Range(4.0f, 10.0f)) + position;
		Vector3 b = new Vector3(Random.Range(-4.0f, -10.0f), 0, Random.Range(4.0f, 10.0f)) + position;
		Vector3 c = new Vector3(Random.Range(-4.0f, -10.0f), 0, Random.Range(-4.0f, -10.0f)) + position;
		Vector3 d = new Vector3(Random.Range(4.0f, 10.0f), 0, Random.Range(-4.0f, -10.0f)) + position;

        float height = Random.Range(30.0f, 60.0f); 

		Vector3 e = new Vector3(0, height, 0) + position;
		Vector3 f = new Vector3(0, height, 0) + position;
		Vector3 g = new Vector3(0, height, 0) + position;
		Vector3 h = new Vector3(0, height, 0) + position;

        createFaces(a, b, c, d);
        createFaces(e, f, g, h);
        createFaces(a, b, f, e);
		createFaces(b, c, g, f);
		createFaces(d, a, e, h);
		createFaces(c, d, h, g);

	}

	void createIciclesField()
    {
		for(int i = 0; i < 20; i = i + 2)
        {
            Vector3 position = new Vector3(i*5 /**Random.Range(-7,7))*/, 0,0);
				createIcicles(position);
        }

        for(int i = 0; i < 20; i = i + 2)
        {
            Vector3 position = new Vector3(i*5 /**Random.Range(-7,7))*/, 0,50);
				createIcicles(position);
        }

		meshicicles.vertices = verticesicicles.ToArray();
		meshicicles.normals = normalsicicles.ToArray();
		meshicicles.triangles = facesicicles.ToArray();
	}
}