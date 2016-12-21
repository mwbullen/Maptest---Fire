using UnityEngine;
using System.Collections;

public class TileInfo : MonoBehaviour {

	public int TileID;

	public bool Walkable;

	public float foodChance = 0f;
	public float randomAttackChance =0f;
	//public bool hasFood = false;
	bool hasFoodBool;

	public float visibilityModifier = 1f;
	public float foodConsumptionModifier = 1f;
	GameObject foodObject;

	public bool hasFood{
		get {return hasFoodBool; }
		set {
			hasFoodBool = value;
			if (value) {
				foodObject = createFoodObject ();

			} else {//if food consumed, destroy food object
				if (foodObject) {
					GameObject.Destroy (foodObject);
				}
			}
		}
	}

	// Use this for initialization
	void Start () {


	}

	public void initFoodState() {
		float foodTest = Random.Range (0, 100);

		if (foodTest < foodChance) {
			//add food
			hasFood = true;

		}
	}

	GameObject createFoodObject() {
		GameObject gameControl = GameObject.FindGameObjectWithTag ("GameControl");

		GameObject foodPreFab = gameControl.GetComponent<MapGeneration> ().foodPrefab;

		GameObject newFoodObject = GameObject.Instantiate (foodPreFab);
		newFoodObject.transform.parent = gameObject.transform;
		newFoodObject.transform.localPosition = new Vector3 (0, 0, 0);
	
		return newFoodObject;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
