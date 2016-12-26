using UnityEngine;
using System.Collections;

public class planeSpeed : MonoBehaviour {

	public float baseAirSpeed = 10f;
	public float turboModifier = 1.5f;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		float airSpeed = baseAirSpeed;

		if (Input.GetKey(KeyCode.LeftShift)) {
			airSpeed *= turboModifier;
		}

		gameObject.transform.Translate (0, 0, airSpeed * Time.deltaTime);

	}
}
