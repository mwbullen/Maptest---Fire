using UnityEngine;
using System.Collections;

public class Scoring : MonoBehaviour {

	public int startingNumTrees;
	public int currentNumTrees;

	public GameObject treeCounterText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		currentNumTrees = gameObject.GetComponent<MapStatus> ().get_numberofTrees();

		treeCounterText.GetComponent<UnityEngine.UI.Text> ().text = currentNumTrees.ToString () + " / " + startingNumTrees;
	}

	public void initializeCounts() {
		startingNumTrees = gameObject.GetComponent<MapStatus> ().get_numberofTrees();

	}
}
