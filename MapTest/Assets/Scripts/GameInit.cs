using UnityEngine;
using System.Collections;

public class GameInit : MonoBehaviour {


	// Use this for initialization
	void Start () {
		//gameObject.GetComponent<MapGeneration> ().LoadSavedMap();

		startGame ();


	}

	void startGame() {
		gameObject.GetComponent<MapStatus> ().LoadorCreateMap ();
		//gameObject.GetComponent<MapStatus> ().showPreviousTiles ();
		gameObject.GetComponent<MapStatus> ().showAllTiles();

		Camera.main.GetComponent<cameraLocationSetup> ().setCameraLocation ();
		//gameObject.GetComponent<TurnManagement> ().updateUIInfo ();
	}

	// Update is called once per frame
	void Update () {
	
	}



	public void NewGame() {
		//delete save files
		gameObject.GetComponent<SaveLoad>().deleteSaveGame();

		//reload Scene;

		UnityEngine.SceneManagement.SceneManager.LoadScene (0);
	}
}
