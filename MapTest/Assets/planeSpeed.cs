using UnityEngine;
using System.Collections;

public class planeSpeed : MonoBehaviour {

	public float baseAirSpeed = 10f;
	public float turboModifier = 1.5f;

	public float turboFuelCapacity;
	public float currentTurboFuel;

	// Use this for initialization
	void Start () {
		currentTurboFuel = turboFuelCapacity;
	}
	
	// Update is called once per frame
	void Update () {
		float airSpeed = baseAirSpeed;
		/*


		if (Input.GetKey (KeyCode.LeftShift) && currentTurboFuel > 0) {
			currentTurboFuel -= Time.deltaTime;
			airSpeed *= turboModifier;

		} else {
			currentTurboFuel = Mathf.Clamp (currentTurboFuel + (Time.deltaTime), 0, turboFuelCapacity);				
		}
		*/
		gameObject.transform.Translate (0, 0, airSpeed * Time.deltaTime);

	}
}
