using UnityEngine;
using System.Collections;
using HutongGames.PlayMaker;

public class TribeMovement : MonoBehaviour {

	[HideInInspector] public GameObject currentTile;
	[HideInInspector] public int rowSize;

	GameObject gameControl;


	// Use this for initialization
	void Start () {
		gameControl = GameObject.FindGameObjectWithTag ("GameControl");

		rowSize = gameControl.GetComponent<MapGeneration> ().rowSize;

		//SpawnatLastTile ();
	}

	int currentTileID {
		get {
			return gameObject.GetComponent<TribeStatus> ().tribeInfo.currentTileID;

		}

		set {
			gameObject.GetComponent<TribeStatus> ().tribeInfo.currentTileID = value;

		}
	}


	public void SpawnatLastTile() {
		GameObject lastTile = gameControl.GetComponent<MapStatus> ().DisplayTile (currentTileID);

		gameObject.transform.position = lastTile.transform.position;

		//gameObject.GetComponent<tribeSightRange>().
	}

	// Update is called once per frame
	void Update () {
	}

	public void MovetoTile(GameObject targetTile ) {		
		PlayMakerFSM movementFsm = gameObject.GetComponent<PlayMakerFSM> ();

		//need to confirm target tile is walkable
		if (targetTile.GetComponent<TileInfo> ().Walkable) {
			movementFsm.FsmVariables.GetFsmGameObject ("targetTile").Value = targetTile;
			movementFsm.SendEvent ("Move to Tile");

			currentTileID = targetTile.GetComponent<TileInfo> ().TileID;

			//gameObject.SendMessage ("updateTilesInRange");
			gameObject.GetComponent<tribeSightRange>().updateTilesInRange(targetTile.GetComponent<TileInfo>().visibilityModifier);

			if (targetTile.GetComponent<TileInfo> ().hasFood) {

				//gameObject.GetComponent<TribeStatus> ().tribeInfo.foodStorage += Mathf.Clamp( Mathf.RoundToInt( Random.Range (10f, 100f));

				gameObject.GetComponent<TribeStatus> ().addFood (20);

				targetTile.GetComponent<TileInfo> ().hasFood = false;
			}

			gameControl.GetComponent<TurnManagement> ().finishMove ();
		}

	}	


	// Directional movement

	public void MoveUp() {
		int targetTileID = currentTileID + rowSize;

		MovetoTile (gameControl.GetComponent<MapStatus> ().DisplayTile (targetTileID));

	}

	public void MoveDown() {
		int targetTileID = currentTileID - rowSize;

		MovetoTile (gameControl.GetComponent<MapStatus> ().DisplayTile (targetTileID));

	}

	public void MoveLeft() {
		int targetTileID = currentTileID -1;

		MovetoTile (gameControl.GetComponent<MapStatus> ().DisplayTile (targetTileID));

	}

	public void MoveRight() {
		int targetTileID = currentTileID + 1;

		MovetoTile (gameControl.GetComponent<MapStatus> ().DisplayTile (targetTileID));

	}
}
