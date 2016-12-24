using UnityEngine;
using System.Collections;

public class planeActions : MonoBehaviour {
	GameObject gameControl;
	// Use this for initialization
	void Start () {
		gameControl = GameObject.FindGameObjectWithTag ("GameControl");

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space)) {
			clearTileBelow ();



		}
	}

	void clearTileBelow() {
		int aboveTileID = gameObject.GetComponent<planeTileTracking> ().aboveTileID;

		GameObject aboveTile = gameControl.GetComponent<MapStatus> ().getTileatIndex (aboveTileID);

		//can't clear tile if burning
		if (aboveTile != null && aboveTile.GetComponent<TileInfo> ().onFire == false) {
			char tileType = gameControl.GetComponent<MapStatus> ().mapInfo.mapSourceString.ToCharArray () [aboveTileID];

			if (tileType == 'T') {
				gameControl.GetComponent<MapStatus> ().updateTileAtIndex (aboveTileID, '_');
			}
		}


	}
}
