using UnityEngine;
using System.Collections;

public class fireControl : MonoBehaviour {
	public float fireInterval = 5f;
	public int numberRandomFires = 3;

	public float timeSinceLastFireInterval = 0f;
	public int numberRandomFiresStarted = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceLastFireInterval += Time.deltaTime;

		if (numberRandomFiresStarted < numberRandomFires && timeSinceLastFireInterval > fireInterval) {
			startNewFire ();
			timeSinceLastFireInterval = 0;
			numberRandomFiresStarted += 1;
		}
				
	}

	void startNewFire() {
		MapStatus currentMapStatus = gameObject.GetComponent<MapStatus> ();

		int randomTileID = UnityEngine.Random.Range (1, currentMapStatus.mapInfo.mapSourceString.Length);

		char randomTileType = currentMapStatus.mapInfo.mapSourceString.ToCharArray() [randomTileID];

		GameObject randomTile = currentMapStatus.getTileatIndex (randomTileID);

		if (randomTileType == 'T' && randomTile.GetComponent<TileInfo>().onFire == false ) {
			randomTile.GetComponent<TileInfo> ().catchFire (randomTile.GetComponent<TileInfo> ().defaultInitalBurnRate);

		}


	}
}
