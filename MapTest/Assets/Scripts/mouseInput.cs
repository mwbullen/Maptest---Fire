using UnityEngine;
using System.Collections;

public class mouseInput : MonoBehaviour {
	GameObject terrain;

	// Use this for initialization
	void Start () {
		terrain = GameObject.FindGameObjectWithTag ("Ground");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			//Debug.Log("Click");

			RaycastHit r = new RaycastHit();
			Ray cameraRay = Camera.main.ScreenPointToRay (Input.mousePosition);

			Physics.Raycast (cameraRay, out r);

			if (r.collider.gameObject.tag == "Tile") {
				//Debug.Log (r.point);

				GameObject selectedTile = r.collider.gameObject;

				selectedTile.GetComponent<TileInfo> ().catchFire (1);
			}
		}
	}


}
