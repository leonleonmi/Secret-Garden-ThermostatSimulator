using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Labyrinth : MonoBehaviour
{
  // Start is called before the first frame update

	GameObject wall;
	
	
	Mesh mesh, meshwall;

	public float interval = 0.5f;
	float nextTime = 0;

	// Punkte der zwei Dreiecke, die ein Rechteck ergeben
	Vector3 a, b, c, d, e, f;

	List<Vector3> vertices;  //Punkte
	List<Vector3> normals;   //Sichtrichtung Vektor
	List<int> faces;         //Dreiecke

	List<Vector3> verticeswall;  //Liste fuer wall
	List<Vector3> normalswall;
	List<int> facesmaze;

	int counter = 0;         //Fuer weitere Punkte
	int countertown = 0;

	
	
	

	



	void Start()
     {
		vertices = new List<Vector3>();
		normals = new List<Vector3>();
		faces = new List<int>();

		verticeswall = new List<Vector3>();
		normalswall = new List<Vector3>();
		facesmaze = new List<int>();
	
		//Wand erstellen
		wall = new GameObject("wall");
		wall.AddComponent<MeshFilter>();
		wall.AddComponent<MeshRenderer>();   
		meshwall = wall.GetComponent<MeshFilter>().mesh;
		meshwall.Clear();

		//Material des Maze
		Renderer rend = wall.GetComponent<Renderer>();
		rend.material = new Material(Shader.Find("Diffuse"));

		//Maze bauen
		createMaze();


        

		

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
		verticeswall.Add(a);
		verticeswall.Add(b);
		verticeswall.Add(c);
		verticeswall.Add(d);

		Vector3 normale = calcNormal(c, b, a);
		Debug.Log(normale);

		normalswall.Add(normale);
		normalswall.Add(normale);
		normalswall.Add(normale);
		normalswall.Add(normale);

		//erstes Dreieck
		facesmaze.Add(0 + countertown);
		facesmaze.Add(2 + countertown);
		facesmaze.Add(1 + countertown);

		//zweites Dreieck
		facesmaze.Add(0 + countertown);
		facesmaze.Add(3 + countertown);
		facesmaze.Add(2 + countertown);

		countertown += 4;
	}

	//In dieser Funktion wird eine Wall erstellt. Dazu werden die Vektorpunkte in einer createFace Funktion verbunden, um die jeweiligen Seiten des Hauses zu bilden
	void createwall(Vector3 position)
    {
		float hoehe = (6.0f);   
		Vector3 a = new Vector3(0, 0, 30) + position;
		Vector3 b = new Vector3(-1, 0, 30) + position;
		Vector3 c = new Vector3(-1, 0, -1) + position;
		Vector3 d = new Vector3(0, 0, -1) + position;

		Vector3 e = new Vector3(0, hoehe, 30) + position;
		Vector3 f = new Vector3(-1, hoehe, 30) + position;
		Vector3 g = new Vector3(-1, hoehe, -1) + position;
		Vector3 h = new Vector3(0, hoehe, -1) + position;

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

	void createwall2(Vector3 position)
    {
		float hoehe = (6.0f);   //Der Y-Wert des Daches variiert von 3-9, damit die Haeuser unterschiedliche Hoehen haben
		Vector3 a = new Vector3(0, 0, 30) + position;
		Vector3 b = new Vector3(-1, 0, 30) + position;
		Vector3 c = new Vector3(-1, 0, -1) + position;
		Vector3 d = new Vector3(0, 0, -1) + position;

		Vector3 e = new Vector3(0, hoehe, 30) + position;
		Vector3 f = new Vector3(-1, hoehe, 30) + position;
		Vector3 g = new Vector3(-1, hoehe, -1) + position;
		Vector3 h = new Vector3(0, hoehe, -1) + position;

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

	void createwall3(Vector3 position)
    {
		float hoehe = (6.0f);   //Der Y-Wert des Daches variiert von 3-9, damit die Haeuser unterschiedliche Hoehen haben
		Vector3 a = new Vector3(17, 0, 0) + position;
		Vector3 b = new Vector3(-1, 0, 0) + position;
		Vector3 c = new Vector3(-1, 0, -1) + position;
		Vector3 d = new Vector3(17, 0, -1) + position;

		Vector3 e = new Vector3(17, hoehe, 0) + position;
		Vector3 f = new Vector3(-1, hoehe, 0) + position;
		Vector3 g = new Vector3(-1, hoehe, -1) + position;
		Vector3 h = new Vector3(17, hoehe, -1) + position;

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

	void createwall4(Vector3 position)
    {
		float hoehe = (20.0f);   //Der Y-Wert des Daches variiert von 3-9, damit die Haeuser unterschiedliche Hoehen haben
		Vector3 a = new Vector3(10, 0, 0) + position;
		Vector3 b = new Vector3(-1, 0, 0) + position;
		Vector3 c = new Vector3(-1, 0, -1) + position;
		Vector3 d = new Vector3(10, 0, -1) + position;

		Vector3 e = new Vector3(10, hoehe, 0) + position;
		Vector3 f = new Vector3(-1, hoehe, 0) + position;
		Vector3 g = new Vector3(-1, hoehe, -1) + position;
		Vector3 h = new Vector3(10, hoehe, -1) + position;

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


	void wand1(Vector3 position)
	 {
		float hoehe = (6.0f);   //Der Y-Wert des Daches variiert von 3-9, damit die Haeuser unterschiedliche Hoehen haben
		Vector3 a = new Vector3(0, 0, 2) + position;
		Vector3 b = new Vector3(-1, 0, 2) + position;
		Vector3 c = new Vector3(-1, 0, -1) + position;
		Vector3 d = new Vector3(0, 0, -1) + position;

		Vector3 e = new Vector3(0, hoehe, 2) + position;
		Vector3 f = new Vector3(-1, hoehe, 2) + position;
		Vector3 g = new Vector3(-1, hoehe, -1) + position;
		Vector3 h = new Vector3(0, hoehe, -1) + position;

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

	void wand2(Vector3 position)
	 {
		float hoehe = (6.0f);   //Der Y-Wert des Daches variiert von 3-9, damit die Haeuser unterschiedliche Hoehen haben
		Vector3 a = new Vector3(0, 0, 16) + position;
		Vector3 b = new Vector3(-1, 0, 16) + position;
		Vector3 c = new Vector3(-1, 0, -1) + position;
		Vector3 d = new Vector3(0, 0, -1) + position;

		Vector3 e = new Vector3(0, hoehe, 16) + position;
		Vector3 f = new Vector3(-1, hoehe, 16) + position;
		Vector3 g = new Vector3(-1, hoehe, -1) + position;
		Vector3 h = new Vector3(0, hoehe, -1) + position;

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

	void wand3(Vector3 position)
    {
		float hoehe = (6.0f);   //Der Y-Wert des Daches variiert von 3-9, damit die Haeuser unterschiedliche Hoehen haben
		Vector3 a = new Vector3(4, 0, 0) + position;
		Vector3 b = new Vector3(-1, 0, 0) + position;
		Vector3 c = new Vector3(-1, 0, -1) + position;
		Vector3 d = new Vector3(4, 0, -1) + position;

		Vector3 e = new Vector3(4, hoehe, 0) + position;
		Vector3 f = new Vector3(-1, hoehe, 0) + position;
		Vector3 g = new Vector3(-1, hoehe, -1) + position;
		Vector3 h = new Vector3(4, hoehe, -1) + position;

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

	void wand4(Vector3 position)
    {
		float hoehe = (6.0f);   //Der Y-Wert des Daches variiert von 3-9, damit die Haeuser unterschiedliche Hoehen haben
		Vector3 a = new Vector3(4, 0, 0) + position;
		Vector3 b = new Vector3(-1, 0, 0) + position;
		Vector3 c = new Vector3(-1, 0, -1) + position;
		Vector3 d = new Vector3(4, 0, -1) + position;

		Vector3 e = new Vector3(4, hoehe, 0) + position;
		Vector3 f = new Vector3(-1, hoehe, 0) + position;
		Vector3 g = new Vector3(-1, hoehe, -1) + position;
		Vector3 h = new Vector3(4, hoehe, -1) + position;

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

	void wand5(Vector3 position)
	 {
		float hoehe = (6.0f);   //Der Y-Wert des Daches variiert von 3-9, damit die Haeuser unterschiedliche Hoehen haben
		Vector3 a = new Vector3(0, 0, 20) + position;
		Vector3 b = new Vector3(-1, 0, 20) + position;
		Vector3 c = new Vector3(-1, 0, -1) + position;
		Vector3 d = new Vector3(0, 0, -1) + position;

		Vector3 e = new Vector3(0, hoehe, 20) + position;
		Vector3 f = new Vector3(-1, hoehe, 20) + position;
		Vector3 g = new Vector3(-1, hoehe, -1) + position;
		Vector3 h = new Vector3(0, hoehe, -1) + position;

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

	void wand6(Vector3 position)
	 {
		float hoehe = (6.0f);   //Der Y-Wert des Daches variiert von 3-9, damit die Haeuser unterschiedliche Hoehen haben
		Vector3 a = new Vector3(0, 0, 15) + position;
		Vector3 b = new Vector3(-1, 0, 15) + position;
		Vector3 c = new Vector3(-1, 0, -1) + position;
		Vector3 d = new Vector3(0, 0, -1) + position;

		Vector3 e = new Vector3(0, hoehe, 15) + position;
		Vector3 f = new Vector3(-1, hoehe, 15) + position;
		Vector3 g = new Vector3(-1, hoehe, -1) + position;
		Vector3 h = new Vector3(0, hoehe, -1) + position;

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

	void wand7(Vector3 position)
    {
		float hoehe = (6.0f);   //Der Y-Wert des Daches variiert von 3-9, damit die Haeuser unterschiedliche Hoehen haben
		Vector3 a = new Vector3(4, 0, 0) + position;
		Vector3 b = new Vector3(-1, 0, 0) + position;
		Vector3 c = new Vector3(-1, 0, -1) + position;
		Vector3 d = new Vector3(4, 0, -1) + position;

		Vector3 e = new Vector3(4, hoehe, 0) + position;
		Vector3 f = new Vector3(-1, hoehe, 0) + position;
		Vector3 g = new Vector3(-1, hoehe, -1) + position;
		Vector3 h = new Vector3(4, hoehe, -1) + position;

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

	void wand8(Vector3 position)
	 {
		float hoehe = (6.0f);   //Der Y-Wert des Daches variiert von 3-9, damit die Haeuser unterschiedliche Hoehen haben
		Vector3 a = new Vector3(0, 0, 6) + position;
		Vector3 b = new Vector3(-1, 0, 6) + position;
		Vector3 c = new Vector3(-1, 0, -1) + position;
		Vector3 d = new Vector3(0, 0, -1) + position;

		Vector3 e = new Vector3(0, hoehe, 6) + position;
		Vector3 f = new Vector3(-1, hoehe, 6) + position;
		Vector3 g = new Vector3(-1, hoehe, -1) + position;
		Vector3 h = new Vector3(0, hoehe, -1) + position;

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

	void wand9(Vector3 position)
    {
		float hoehe = (6.0f);   //Der Y-Wert des Daches variiert von 3-9, damit die Haeuser unterschiedliche Hoehen haben
		Vector3 a = new Vector3(4, 0, 0) + position;
		Vector3 b = new Vector3(-1, 0, 0) + position;
		Vector3 c = new Vector3(-1, 0, -1) + position;
		Vector3 d = new Vector3(4, 0, -1) + position;

		Vector3 e = new Vector3(4, hoehe, 0) + position;
		Vector3 f = new Vector3(-1, hoehe, 0) + position;
		Vector3 g = new Vector3(-1, hoehe, -1) + position;
		Vector3 h = new Vector3(4, hoehe, -1) + position;

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

	void wand10(Vector3 position)
	 {
		float hoehe = (6.0f);   //Der Y-Wert des Daches variiert von 3-9, damit die Haeuser unterschiedliche Hoehen haben
		Vector3 a = new Vector3(0, 0, 17) + position;
		Vector3 b = new Vector3(-1, 0, 17) + position;
		Vector3 c = new Vector3(-1, 0, -1) + position;
		Vector3 d = new Vector3(0, 0, -1) + position;

		Vector3 e = new Vector3(0, hoehe, 17) + position;
		Vector3 f = new Vector3(-1, hoehe, 17) + position;
		Vector3 g = new Vector3(-1, hoehe, -1) + position;
		Vector3 h = new Vector3(0, hoehe, -1) + position;

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

	void wand11(Vector3 position)
	 {
		float hoehe = (6.0f);   //Der Y-Wert des Daches variiert von 3-9, damit die Haeuser unterschiedliche Hoehen haben
		Vector3 a = new Vector3(0, 0, 2) + position;
		Vector3 b = new Vector3(-1, 0, 2) + position;
		Vector3 c = new Vector3(-1, 0, -1) + position;
		Vector3 d = new Vector3(0, 0, -1) + position;

		Vector3 e = new Vector3(0, hoehe, 2) + position;
		Vector3 f = new Vector3(-1, hoehe, 2) + position;
		Vector3 g = new Vector3(-1, hoehe, -1) + position;
		Vector3 h = new Vector3(0, hoehe, -1) + position;

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
	void createMaze()
    {
		for(int i = 1; i < 2; i++)
        {
			for(int j = 1; j < 2; j++)
            {
				Vector3 position = new Vector3(i * 1, 20, j * 1);
				createwall(position);
            }
        }

		for(int i = 22; i < 23; i++)
        {
			for(int j = 1; j < 2; j++)
            {
				Vector3 position = new Vector3(i * 1, 20, j * 1);
				createwall2(position);
            }
        }

		for(int i = 1; i < 2; i++)
        {
			for(int j = 1; j < 2; j++)
            {
				Vector3 position = new Vector3(i * 1, 20, j * 1);
				createwall3(position);
            }
        }

		for(int i = 5; i < 6; i++)
        {
			for(int j = 31; j < 32; j++)
            {
				Vector3 position = new Vector3(i * 1, 20, j * 1);
				createwall3(position);
            }
        }

		for(int i = 5; i < 6; i++)
        {
			for(int j = 28; j < 29; j++)
            {
				Vector3 position = new Vector3(i * 1, 20, j * 1);
				wand1(position);
            }
        }

		for(int i = 5; i < 6; i++)
        {
			for(int j = 7; j < 8; j++)
            {
				Vector3 position = new Vector3(i * 1, 20, j * 1);
				wand2(position);
            }
        }

		for(int i = 5; i < 6; i++)
        {
			for(int j = 6; j < 7; j++)
            {
				Vector3 position = new Vector3(i * 1, 20, j * 1);
				wand3(position);
            }
        }

		for(int i = 5; i < 6; i++)
        {
			for(int j = 27; j < 28; j++)
            {
				Vector3 position = new Vector3(i * 1, 20, j * 1);
				wand4(position);
            }
        }

		for(int i = 9; i < 10; i++)
        {
			for(int j = 6; j < 7; j++)
            {
				Vector3 position = new Vector3(i * 1, 20, j * 1);
				wand5(position);
            }
        }

		for(int i = 13; i < 14; i++)
        {
			for(int j = 1; j < 2; j++)
            {
				Vector3 position = new Vector3(i * 1, 20, j * 1);
				wand6(position);
            }
        }

		for(int i = 13; i < 14; i++)
        {
			for(int j = 9; j < 10; j++)
            {
				Vector3 position = new Vector3(i * 1, 20, j * 1);
				wand7(position);
            }
        }

		for(int i = 13; i < 14; i++)
        {
			for(int j = 21; j < 22; j++)
            {
				Vector3 position = new Vector3(i * 1, 20, j * 1);
				wand8(position);
            }
        }

		for(int i = 13; i < 14; i++)
        {
			for(int j = 27; j < 28; j++)
            {
				Vector3 position = new Vector3(i * 1, 20, j * 1);
				wand9(position);
            }
        }

		for(int i = 17; i < 18; i++)
        {
			for(int j = 6; j < 7; j++)
            {
				Vector3 position = new Vector3(i * 1, 20, j * 1);
				wand10(position);
            }
        }

		for(int i = 17; i < 18; i++)
        {
			for(int j = 28; j < 29; j++)
            {
				Vector3 position = new Vector3(i * 1, 20, j * 1);
				wand11(position);
            }
        }

		

		

		//Mesh townMesh = new Mesh();
		//wall.GetComponent<MeshFilter>().mesh = townMesh;
		meshwall.vertices = verticeswall.ToArray();
		meshwall.normals = normalswall.ToArray();
		meshwall.triangles = facesmaze.ToArray();
	}


	

	

	


	
	// Update is called once per frame
	void Update()
	{

	}
}