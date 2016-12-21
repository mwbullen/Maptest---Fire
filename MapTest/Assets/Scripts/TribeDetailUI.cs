using UnityEngine;
using System.Collections;

public class TribeDetailUI : MonoBehaviour {
	public Tribesman tribeMember;

	public GameObject nameText;
	public GameObject healthText;
	public GameObject ageText;
	public GameObject genderText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (tribeMember.Health < 0) {
			GameObject.Destroy (gameObject);
		}
	}

	public void updateDisplay() {
		nameText.GetComponent<UnityEngine.UI.Text> ().text = tribeMember.Name;
		healthText.GetComponent<UnityEngine.UI.Text> ().text = tribeMember.Health.ToString() + " / " + tribeMember.maxHealth.ToString();
		ageText.GetComponent<UnityEngine.UI.Text> ().text = tribeMember.Age.ToString();
		genderText.GetComponent<UnityEngine.UI.Text> ().text = tribeMember.Gender.ToString ();
	}


}
