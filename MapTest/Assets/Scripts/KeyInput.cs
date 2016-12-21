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
			if (Input.GetKey (KeyCode.UpArrow)) {
				tribe = GameObject.FindGameObjectWithTag ("Tribe");
				timeSinceKeyPress = 0;

				tribe.SendMessage ("MoveUp");
			} else if (Input.GetKey (KeyCode.DownArrow)) {
				tribe = GameObject.FindGameObjectWithTag ("Tribe");
				timeSinceKeyPress = 0;

				tribe.SendMessage ("MoveDown");
			} else if (Input.GetKey (KeyCode.LeftArrow)) {
				tribe = GameObject.FindGameObjectWithTag ("Tribe");
				timeSinceKeyPress = 0;

				tribe.SendMessage ("MoveLeft");
			} else if (Input.GetKey (KeyCode.RightArrow)) {
				tribe = GameObject.FindGameObjectWithTag ("Tribe");
				timeSinceKeyPress = 0;

				tribe.SendMessage ("MoveRight");
			}
		}
	}
}
