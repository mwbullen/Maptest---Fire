using UnityEngine;
using System.Collections;

public class cameraLocationSetup : MonoBehaviour {

	GameObject gameControl;

	// Use this for initialization
	void Start () {
		


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setCameraLocation() {
		gameControl = GameObject.FindGameObjectWithTag ("GameControl");

		MapInfo currentMapInfo = gameControl.GetComponent<MapStatus> ().mapInfo;


		transform.position = new Vector3 (currentMapInfo.rowSize / 2, currentMapInfo.rowSize /2, 0);

		gameObject.GetComponent<Camera> ().orthographicSize = currentMapInfo.rowSize/2;
	}
}
