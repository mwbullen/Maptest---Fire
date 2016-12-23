using UnityEngine;
using System.Collections;

public class planeSteering : MonoBehaviour {

	public float baseTurnRate = 10f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.RightArrow)) {
			steerPlane(baseTurnRate);
		}

		if (Input.GetKey(KeyCode.LeftArrow)) {
			steerPlane(baseTurnRate *-1);
		}
	}

	void steerPlane(float turnRate) {
		transform.Rotate (new Vector3 (0, turnRate, 0));

	}
		
}
