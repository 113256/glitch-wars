using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;
	private GameObject DefenderParent;

	// Use this for initialization
	void Start () {
		DefenderParent = GameObject.Find("Defender");
		//good unity practice- create if it doesnt exist
		if (!DefenderParent) {
			DefenderParent = new GameObject("Defender");}
	}
	
	// Update is called once per frame
	void Update () {
	
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

		GameObject defender = Instantiate (Button.selectedDefender, worldUnits, Quaternion.identity) as GameObject;
		defender.transform.parent = DefenderParent.transform;
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
