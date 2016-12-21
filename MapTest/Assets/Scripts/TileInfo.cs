using UnityEngine;
using System.Collections;

public class TileInfo : MonoBehaviour {

	public int TileID;

	//public bool Walkable;

	//public float visibilityModifier = 1f;

	public bool flammable = false;

	public bool onFire = false;

	public float fuel = 10f;
	public float burnRate = 0f;
	public float fireResistance = 5f;

	public GameObject fireParticleObject;
	public GameObject fireParticlePrefab;

	GameObject gameControl;
	// Use this for initialization
	void Start () {
		gameControl = GameObject.FindGameObjectWithTag ("GameControl");
	}

	// Update is called once per frame
	void Update () {
		if (onFire) {
			fuel -= (burnRate * Time.deltaTime);

			//send fire to adjacent tiles
			foreach (int adjacentTileInt in gameControl.GetComponent<MapStatus>().getAdjacentTiles(TileID)) {
				GameObject adjacentTile = gameControl.GetComponent<MapStatus> ().DisplayTile (adjacentTileInt);

				if (adjacentTile.GetComponent<TileInfo> ().flammable) {
					adjacentTile.GetComponent<TileInfo> ().receiveFire (burnRate);
				}
			}

			if (fuel <= 0) {//check if fire is out				
				onFire = false;
				burnRate = 0;
				GameObject.Destroy (gameObject);
			}
		}
	}


	public void catchFire(float initialBurnRate) {
		onFire = true;
		burnRate = initialBurnRate;

		fireParticleObject = GameObject.Instantiate (fireParticlePrefab);
		fireParticleObject.transform.parent = gameObject.transform;
		fireParticleObject.transform.localPosition = new Vector3 (0, 0, 0);

	}

	public void receiveFire (float reductionAmount) {
		if (!onFire) {
			fireResistance -= reductionAmount;
			if (fireResistance < 0) {//caught fire
				catchFire (1);
			}
		}
	}
}
