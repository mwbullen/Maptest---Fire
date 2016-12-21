using UnityEngine;
using System.Collections;

public class GameInit : MonoBehaviour {

	public GameObject tribePrefab;

	// Use this for initialization
	void Start () {
		//gameObject.GetComponent<MapGeneration> ().LoadSavedMap();

		startGame ();


	}

	void startGame() {
		gameObject.GetComponent<MapStatus> ().LoadorCreateMap ();
		//gameObject.GetComponent<MapStatus> ().showPreviousTiles ();
		gameObject.GetComponent<MapStatus> ().showAllTiles();

		//gameObject.GetComponent<TurnManagement> ().updateUIInfo ();
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void CreateTribe() {
		GameObject newTribe = GameObject.Instantiate (tribePrefab);

		//assign tribe prefab where needed
		Camera.main.SendMessage ("SetFollowTarget", newTribe);

		gameObject.GetComponent<mouseInput>().Tribe  = newTribe;
	}

	public void NewGame() {
		//delete save files
		gameObject.GetComponent<SaveLoad>().deleteSaveGame();

		//reload Scene;

		UnityEngine.SceneManagement.SceneManager.LoadScene (0);
	}
}
