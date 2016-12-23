using UnityEngine;
using System.Collections;

public class KeyInput : MonoBehaviour {

	GameObject tribe;

	float keyPressInterval = .75f;
	float timeSinceKeyPress = 0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (timeSinceKeyPress < keyPressInterval) {
			timeSinceKeyPress += Time.deltaTime;
		}

		if (timeSinceKeyPress >= keyPressInterval) {
		   if (Input.GetKey (KeyCode.LeftArrow)) {
				GameObject plane = GameObject.FindGameObjectWithTag ("Player");
				timeSinceKeyPress = 0;

				plane.GetComponent<PlayMakerFSM> ().SendEvent ("Left");

				//tribe.SendMessage ("MoveLeft");
			} else if (Input.GetKey (KeyCode.RightArrow)) {
				GameObject plane = GameObject.FindGameObjectWithTag ("Player");
				timeSinceKeyPress = 0;

				plane.GetComponent<PlayMakerFSM> ().SendEvent ("Right");
			}
		}
	}
}
