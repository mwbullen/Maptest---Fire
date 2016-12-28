using UnityEngine;
using System.Collections;

public class MapStatus : MonoBehaviour {

	public MapInfo mapInfo;

	public GameObject mapParentPrefab;

	GameObject mapParentObject;

	public GameObject openTilePrefab;
	public GameObject waterTilePrefab;
	public GameObject mountainTilePrefab;
	public GameObject treeTilePrefab;
	public GameObject oilTankTilePrefab;

	// Use this for initialization
	void Start () {
		}

	public void LoadorCreateMap() {
		mapParentObject = GameObject.Instantiate (mapParentPrefab);

		mapInfo = gameObject.GetComponent<SaveLoad> ().LoadSavedMapInfo();

		if (mapInfo == null) {//create new map
			MapGeneration mapGenCom = gameObject.GetComponent<MapGeneration> ();

			string newMapString = mapGenCom.createNewMapString ();
			//Debug.Log ("new mapstring " + newMapString);

			int rowSize = mapGenCom.rowSize;
			int numRows = mapGenCom.numberRows;

			mapInfo = new MapInfo (newMapString, rowSize, numRows);

			gameObject.GetComponent<SaveLoad> ().SaveMapInfo ();
		} 
	}

	/*
	public void showPreviousTiles() {
		foreach (int i in mapInfo.visibleTiles.Keys) {
			DisplayTile(i);
		}
	}
*/

	public int get_numberofTrees() {
		int result = 0;

		foreach (char c in mapInfo.mapSourceString.ToCharArray()) {
			if (c == 'T') {
				result += 1;
			}
		}

		return result;
	}

	public int get_NumberOfActiveFires () {
		int result = 0;

		foreach (TileInfo t in mapParentObject.GetComponentsInChildren<TileInfo>()) {
			if (t.onFire) {
				result += 1;
			}
		}

		return result;
	}

	public void showAllTiles() {
		for (int i = 1; i < mapInfo.mapSourceString.Length; i++) {
			DisplayTile(i);
		}
	}

	public void updateTileAtIndex (int tileIndex, char newChar) {
		mapInfo.updateTileType (tileIndex, newChar);

		GameObject gameControl = GameObject.FindGameObjectWithTag ("GameControl");
		gameControl.GetComponent<SaveLoad> ().SaveMapInfo ();

		GameObject currentTile = getTileatIndex (tileIndex);
		GameObject.Destroy (currentTile);

		createTileforIndex (tileIndex);
	}

	public GameObject getTileatIndex(int tileIndex) {
		foreach (GameObject tileGameObject in GameObject.FindGameObjectsWithTag("Tile")) {
			if (tileGameObject.GetComponent<TileInfo> ().TileID == tileIndex) {//tile is already displayed				
				return tileGameObject;
			} 
		}

		return null;
	}

	public GameObject createTileforIndex(int tileIndex) {
		char tileChar = mapInfo.getTileStringatPosition (tileIndex);

		GameObject tilePrefab = null;

		//Debug.Log (tileIndex);
		//read string and assign prefab
		if (tileChar == '_') {
			tilePrefab = openTilePrefab;
		} else if (tileChar == 'w') {
			tilePrefab = waterTilePrefab;
		} else if (tileChar == 'T') {
			tilePrefab = treeTilePrefab;
		} else if (tileChar == 'm') {
			tilePrefab = mountainTilePrefab;
		} else if (tileChar == 'o') {
			tilePrefab = oilTankTilePrefab;
		}

		float posx =  tileIndex % mapInfo.rowSize;
		float posz = Mathf.Round (tileIndex /mapInfo.rowSize);

		if (tilePrefab != null) {
			//need to calculate coordinates
			GameObject newTile = GameObject.Instantiate (tilePrefab);

			newTile.GetComponent<TileInfo> ().TileID = tileIndex;
			newTile.transform.parent = mapParentObject.transform;
			newTile.transform.Rotate (new Vector3 (90, 0, 0));
			newTile.transform.position = new Vector3 (posx, 0, posz);


			//mapInfo.visibleTiles.Add (tileIndex);
			return newTile;
		}
		return null;
	}

	public GameObject DisplayTile(int tileIndex) {
		//check if tile exists

		foreach (GameObject tileGameObject in GameObject.FindGameObjectsWithTag("Tile")) {
			if (tileGameObject.GetComponent<TileInfo> ().TileID == tileIndex) {//tile is already displayed	
				Debug.Log("tile already displayed");
				return tileGameObject;
			} 
		}

		//if tile does not exist, display
		return createTileforIndex(tileIndex);

	}
	// Update is called once per frame
	void Update () {
	
	}

	public ArrayList getAdjacentTiles(int tileID) {
		int rowSize = gameObject.GetComponent<MapGeneration>().rowSize;

		ArrayList inRangeTileList = new ArrayList ();
		//inRangeTileList.Add (currentTileIndex);

		//int sightRange = Mathf.RoundToInt( baseSightRange * visibilityModifier);

		int rowPosition = tileID % rowSize;

		//check if end tile
		if (rowPosition >0 ) {
			inRangeTileList.Add (tileID - 1);
		}

		if (rowPosition < rowSize - 1) {
			inRangeTileList.Add (tileID + 1);
		}

		inRangeTileList.Add (tileID + rowSize);
		inRangeTileList.Add (tileID - rowSize);


		return inRangeTileList;
	}
}
