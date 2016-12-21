using UnityEngine;
using System.Collections;

public class UILog : MonoBehaviour {

	public GameObject uiLogText;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addLogMessage(string messageText) {
		uiLogText = GameObject.FindGameObjectWithTag ("UILogText");

		uiLogText.GetComponent<UnityEngine.UI.Text> ().text += messageText + "\n";

	}
}
