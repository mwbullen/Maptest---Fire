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

	public void showPreviousTiles() {
		foreach (int i in mapInfo.visibleTiles.Keys) {
			DisplayTile(i);
		}
	}

	public GameObject DisplayTile(int tileIndex) {
		//check if tile exists

		foreach (GameObject tileGameObject in GameObject.FindGameObjectsWithTag("Tile")) {
			if (tileGameObject.GetComponent<TileInfo> ().TileID == tileIndex) {//tile is already displayed				
				return tileGameObject;
			} 
		}

		//if tile does not exist, display

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

			//if not previously shown, random gen food
			if (!mapInfo.visibleTiles.Contains (tileIndex)) {
				newTile.GetComponent<TileInfo> ().initFoodState ();
				mapInfo.visibleTiles.Add (tileIndex, null);

				if (newTile.GetComponent<TileInfo> ().hasFood) {
					mapInfo.foodTiles.Add (tileIndex, null);
				}
			} else { //load previous tile state
				if (mapInfo.foodTiles.Contains(tileIndex)) {
					newTile.GetComponent<TileInfo> ().hasFood = true ;
				}
			}

			//mapInfo.visibleTiles.Add (tileIndex);
			return newTile;
		}
		return null;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
