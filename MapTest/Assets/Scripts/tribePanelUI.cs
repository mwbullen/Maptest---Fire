using UnityEngine;
using System.Collections;

public class tribePanelUI : MonoBehaviour {

	GameObject tribe;

	public GameObject tribeMemberDetailPnlPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void displayTibe() {
		tribe = GameObject.FindGameObjectWithTag ("Tribe");

		foreach (Tribesman tm in tribe.GetComponent<TribeStatus>().tribeInfo.TribeMembers) {
			GameObject newDetailPanel = GameObject.Instantiate (tribeMemberDetailPnlPrefab);

			newDetailPanel.GetComponent<TribeDetailUI> ().tribeMember = tm;
			newDetailPanel.GetComponent<TribeDetailUI> ().updateDisplay ();

		}
	}
}
