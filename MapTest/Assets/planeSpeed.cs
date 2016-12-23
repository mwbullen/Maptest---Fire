using UnityEngine;
using System.Collections;

public class planeSpeed : MonoBehaviour {

	public float airSpeed = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate (0, 0, airSpeed * Time.deltaTime);

	}
}
