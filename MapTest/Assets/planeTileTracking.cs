using UnityEngine;
using System.Collections;

public class planeTileTracking : MonoBehaviour {

	public float rayCastInterval = .1f;
	float timeSinceLastRaycast = 0;

	public int aboveTileID;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeSinceLastRaycast += Time.deltaTime;

		if (timeSinceLastRaycast > rayCastInterval) {
			getTileBelow ();
		}
	}

	void getTileBelow() {
		//check tile below
		Debug.Log("check tile below");
		timeSinceLastRaycast =0;
		aboveTileID = -1;

		RaycastHit rayHit;

		if (Physics.Raycast( new Ray(transform.position, new Vector3(0,-1,0)), out rayHit, 10)) {
			GameObject hitObject = rayHit.collider.gameObject;

			if (hitObject.CompareTag ("Tile")) {
				aboveTileID = hitObject.GetComponent<TileInfo>().TileID;

			}
		}
	}

}
