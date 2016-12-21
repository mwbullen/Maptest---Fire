	using UnityEngine;
using System.Collections;

public class TribeStatus : MonoBehaviour {

	public TribeInfo tribeInfo ;
    GameObject gameControl;

	public GameObject tribeMemberDetailUIPrefab;

	// Use this for initialization
	void Start () {
		gameControl = GameObject.FindGameObjectWithTag ("GameControl");

		tribeInfo = gameControl.GetComponent<SaveLoad> ().LoadSavedTribeInfo();

		if (tribeInfo == null) {
			tribeInfo = new TribeInfo();
		}

		gameObject.GetComponent<TribeMovement> ().SpawnatLastTile ();

		GameObject currentTile = gameControl.GetComponent<MapStatus> ().DisplayTile (tribeInfo.currentTileID);

		gameObject.GetComponent<tribeSightRange> ().updateTilesInRange (currentTile.GetComponent<TileInfo> ().visibilityModifier);

		createTribeMemberUI ();
	}

	void createTribeMemberUI() {
		GameObject tribeUIPanel = GameObject.FindGameObjectWithTag ("TribeUIPanel");

		foreach (Tribesman tm in tribeInfo.TribeMembers) {
			GameObject newUIDetail = GameObject.Instantiate (tribeMemberDetailUIPrefab);
			newUIDetail.GetComponent<TribeDetailUI> ().tribeMember = tm;
			newUIDetail.transform.parent = tribeUIPanel.transform;

			newUIDetail.GetComponent<TribeDetailUI> ().updateDisplay ();
			//newUIDetail.
		}
	}

	public void updateTribeDetailDisplay() {
		GameObject tribeUIPanel = GameObject.FindGameObjectWithTag ("TribeUIPanel");

		tribeUIPanel.BroadcastMessage ("updateDisplay");
	}

	public void addFood(int additionalFood) {
		tribeInfo.foodStorage = Mathf.Clamp (tribeInfo.foodStorage + additionalFood, 0, tribeInfo.maxFoodStorage);
	}

	// Update is called once per frame
	void Update () {
	
	}

	void DayElapsed() {
		//foodStorage =- dailyFoodNeed;

	}

	public void decrementFood() {
		foreach (Tribesman t in tribeInfo.TribeMembers) {
			string logMessage;

			if (tribeInfo.foodStorage > 0) {
				if (t.FoodperDay <= tribeInfo.foodStorage) {//enough food for tribesman
					tribeInfo.foodStorage -= t.FoodperDay;
					logMessage = t.Name + " ate " + t.FoodperDay;

				} else {//some food, but less than needed
					logMessage = t.Name + " ate " + tribeInfo.foodStorage;

				}

			} else { //no food for tribesman
				logMessage = t.Name + " went hungry";
			}
				gameControl.GetComponent<UILog> ().addLogMessage (logMessage);

		}

	}

	public void decrementFood_old() {
		//Debug.Log ("Food");
		//update total daily food req
		tribeInfo.dailyFoodNeed = 0;
		foreach (Tribesman t in tribeInfo.TribeMembers) {
			tribeInfo.dailyFoodNeed += t.FoodperDay;
		}

		//update based on tile modifier
		tribeInfo.dailyFoodNeed *= gameControl.GetComponent<MapStatus>().DisplayTile(tribeInfo.currentTileID).GetComponent<TileInfo>().foodConsumptionModifier;


		float newfoodStorage = tribeInfo.foodStorage - tribeInfo.dailyFoodNeed;

		//food shortage
		if (newfoodStorage < 0) {
			tribeInfo.foodStorage = 0;
			distributeFoodShortfall (newfoodStorage);
		} else { //food surplus
			tribeInfo.foodStorage = newfoodStorage;
			healTribeMembers ();
		}

	}

	void healTribeMembers() {
		foreach (Tribesman tm in tribeInfo.TribeMembers) {
			float newHealth = Mathf.Clamp (tm.Health + tm.FoodperDay, 0, tm.maxHealth);
			tm.Health = newHealth;

		}
	}

	void distributeFoodShortfall(float shortFall) {
		float foodShortfall = Mathf.Abs (shortFall);

		float shortagePerPerson = Mathf.RoundToInt( foodShortfall / tribeInfo.TribeMembers.Count);

		foreach (Tribesman tm in tribeInfo.TribeMembers) {
			tm.decrementHealth (shortagePerPerson);
		}

		checkForDeadTribeMembers ();
	}

	void checkForDeadTribeMembers() {
		ArrayList removeList = new ArrayList();

		foreach (Tribesman tm in tribeInfo.TribeMembers) {
			if (tm.Health < 0) {
				removeList.Add(tm);
			}
		}

		foreach (Tribesman tm in removeList) {
			tribeInfo.TribeMembers.Remove(tm);
		}
	}

}
