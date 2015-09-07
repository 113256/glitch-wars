using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;
	private static GameObject DefenderParent;
	public GameObject[] listOfDefenders; //so that i can spawn them beforehand
	private static bool[,] coordinates = new bool[9, 5];

	// Use this for initialization
	void Start () {
		DefenderParent = GameObject.Find("Defender");
		//good unity practice- create if it doesnt exist
		if (!DefenderParent) {
			DefenderParent = new GameObject("Defender");}

		//spawn some defenders
		spawnOnGrid(2,3,listOfDefenders[1]);
		spawnOnGrid(2,4,listOfDefenders[0]);
		spawnOnGrid(2,2,listOfDefenders[0]);
		spawnOnGrid(1,2,listOfDefenders[4]);
	}


	
	// Update is called once per frame
	void Update () {
	
	}

	public static bool isOccupied(int x, int y){
		return coordinates[x - 1,y - 1] == true;
	}

	//spawn defenders and mark on coordinates array
	public static void spawnOnGrid(int x, int y, GameObject defender){
		GameObject spawnedDefender= Instantiate (defender, new Vector2 (x, y), Quaternion.identity) as GameObject;
		spawnedDefender.transform.parent = DefenderParent.transform;
		coordinates[x - 1,y - 1] = true;
	}

	void OnMouseDown(){
		//calculate world-units position of a click then the nearest play-space grid centre and spawn the currently selected defender there

		//returns PIXEL coordinates of your mouse click
		Vector3 pixelCoord = Input.mousePosition;
		//camera.ScreenToWorldPoint translates pixels to world points/units
		Vector3 worldUnits = CalculateWorldPoint (pixelCoord);
		//round to centre of the grid i clicked on
		worldUnits = SnapToGrid (worldUnits);
		print (worldUnits);

		if (!isOccupied((int)worldUnits.x, (int)worldUnits.y)) {
			GameObject defender = Instantiate (Button.selectedDefender, worldUnits, Quaternion.identity) as GameObject;
			defender.transform.parent = DefenderParent.transform;
		} else {
			print("occupied");
		}
	}


	//snaps to centre of nearest grid
	Vector3 SnapToGrid(Vector3 vector){
		return new Vector2 (Mathf.Round (vector.x), Mathf.Round (vector.y));
	}

	//calculates world point of mouse click
	Vector2 CalculateWorldPoint(Vector3 vector){
		Vector2 worldPoint = myCamera.ScreenToWorldPoint (vector);
		return worldPoint;
	}
}
