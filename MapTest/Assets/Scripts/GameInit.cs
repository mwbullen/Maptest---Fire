using UnityEngine;
using System.Collections;

public class GameInit : MonoBehaviour {

	public GameObject finalScoreText;

	// Use this for initialization
	void Start () {
		//gameObject.GetComponent<MapGeneration> ().LoadSavedMap();

		startGame ();


	}

	void startGame() {
		finalScoreText.transform.parent.gameObject.SetActive (false);

		gameObject.GetComponent<MapStatus> ().LoadorCreateMap ();
		//gameObject.GetComponent<MapStatus> ().showPreviousTiles ();
		gameObject.GetComponent<MapStatus> ().showAllTiles();

		Camera.main.GetComponent<cameraLocationSetup> ().setCameraLocation ();
		//gameObject.GetComponent<TurnManagement> ().updateUIInfo ();

		gameObject.GetComponent<Scoring> ().initializeCounts ();
	}

	// Update is called once per frame
	void Update () {
	
	//check if game still going
		fireControl fireControlCom = gameObject.GetComponent<fireControl>();

		if (fireControlCom.numberRandomFiresStarted == fireControlCom.numberRandomFires) {
			if (gameObject.GetComponent<MapStatus> ().get_NumberOfActiveFires () == 0) {
				endGame ();
			}
		}
	}



	public void NewGame() {
		//delete save files
		gameObject.GetComponent<SaveLoad>().deleteSaveGame();

		//reload Scene;

		UnityEngine.SceneManagement.SceneManager.LoadScene (0);
	}

	public void endGame() {
		Time.timeScale = 0;

		finalScoreText.transform.parent.gameObject.SetActive (true);
		Scoring scoringComponent = gameObject.GetComponent<Scoring> ();

		//Debug.Log (scoringComponent.currentNumTrees);
		//Debug.Log (scoringComponent.startingNumTrees);

		float finalScorePercent = Mathf.Round(((float)scoringComponent.currentNumTrees / (float)scoringComponent.startingNumTrees) * 100);

		Debug.Log (finalScorePercent);

		finalScoreText.GetComponent<UnityEngine.UI.Text>().text = finalScorePercent.ToString() + "% trees saved!";

		
	}
}
