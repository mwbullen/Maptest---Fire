using UnityEngine;
using System.Collections;

public class tribeSightRange : MonoBehaviour {

	[HideInInspector] public GameObject GameControl;

	public int baseSightRange =3;

	// Use this for initialization
	void Start () {
		GameControl = GameObject.FindGameObjectWithTag ("GameControl");

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void updateTilesInRange(float visibilityModifer) {
		
		foreach (int tileIndex in getTilesIndexesinRange(visibilityModifer)) {
			GameControl.SendMessage ("DisplayTile", tileIndex);
		}
	}

	ArrayList getTilesIndexesinRange(float visibilityModifier) {
		
		int currentTileIndex = gameObject.GetComponent<TribeStatus> ().tribeInfo.currentTileID;
		int rowSize = GameControl.GetComponent<MapGeneration>().rowSize;


		//int[] inRangeTiles = {currentTileIndex};

		ArrayList inRangeTileList = new ArrayList ();

		inRangeTileList.Add (currentTileIndex);

		int sightRange = Mathf.RoundToInt( baseSightRange * visibilityModifier);

		//get tiles in same row to display
		for (int i = currentTileIndex - sightRange; i <= currentTileIndex + sightRange; i++) {
			if (i > 0) {
				inRangeTileList.Add (i);
			}
		}

		//int halfSightRange = Mathf.CeilToInt (sightRange / 2);

		//get verticals to display
		for (int i = 0; i <= sightRange; i++) {
			int rowAboveVert = currentTileIndex + (rowSize * i);
			inRangeTileList.Add (rowAboveVert);

			int rowBelowVert = (currentTileIndex - (rowSize *i));
			inRangeTileList.Add (rowBelowVert);

			for (int subI = 0; subI <= sightRange - i; subI++) {
				inRangeTileList.Add (rowAboveVert + subI);
				inRangeTileList.Add (rowAboveVert - subI);
			
				inRangeTileList.Add (rowBelowVert + subI);
				inRangeTileList.Add (rowBelowVert - subI);
			}

		}


		/*
		//get rows above and below
		inRangeTileList.Add (currentTileIndex + rowSize);
		inRangeTileList.Add (currentTileIndex + rowSize + halfSightRange );
		inRangeTileList.Add (currentTileIndex + rowSize - halfSightRange );

		inRangeTileList.Add (currentTileIndex - rowSize);
		inRangeTileList.Add (currentTileIndex - rowSize + halfSightRange );
		inRangeTileList.Add (currentTileIndex - rowSize - halfSightRange );
		*/

		return inRangeTileList;
	}

	int getTileIndexDistance(int indexA, int indexB) {

		return 0;
	}
}
