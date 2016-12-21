using UnityEngine;
using System.Collections;


public class MapGeneration : MonoBehaviour {
	public int rowSize = 200;
	public int numberRows = 10;

	public int waterChanceBase = 5;
	public int waterAdjacentBonus = 20;

	public int mtnChanceBase = 5;
	public int mtnAdjacentBonus = 20;

	public int treeChanceBase = 5;
	public int treeAdjacentBonus = 20;

	public int openChanceBase = 50;

	string mapString;

	public GameObject foodPrefab;


	//public ArrayList mapDefinition = new ArrayList();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	char getTileStringatPosition(int position) {
		if (position > 0) {
			//return mapDefinition [position].ToString();
			return mapString[position];
		} else {
			return ' ';
		}
	}

	char getRandomMapCharforPos(int i) {
		int nextInterval = 0;

		//water
		int[] waterChanceArray = { nextInterval, waterChanceBase };

		if (getTileStringatPosition (i - 1) == 'w') {
			waterChanceArray[1] = waterChanceArray[1] +waterAdjacentBonus;
		}

		if (getTileStringatPosition (i - rowSize) == 'w') {
			waterChanceArray[1] = waterChanceArray[1]  +waterAdjacentBonus;
		}

		nextInterval = waterChanceArray[1] + 1;

		//tree
		int[] treeChanceArray = {nextInterval, nextInterval + treeChanceBase};

		if (getTileStringatPosition (i - 1) == 'T') {
				treeChanceArray[1] = treeChanceArray[1] +treeAdjacentBonus;
		}

		if (getTileStringatPosition (i - rowSize) == 'T') {
				treeChanceArray[1] = treeChanceArray[1]  +treeAdjacentBonus;
		}

		nextInterval = treeChanceArray[1] + 1;

		//mountain
		int[] mtnChanceArray = {nextInterval, nextInterval + mtnChanceBase};

		if (getTileStringatPosition (i - 1) == 'm') {
			mtnChanceArray[1] = mtnChanceArray[1] +mtnAdjacentBonus;
		}

		if (getTileStringatPosition (i - rowSize) == 'm') {
			mtnChanceArray[1] = mtnChanceArray[1]  +mtnAdjacentBonus;
		}

		nextInterval = mtnChanceArray[1] + 1;

		//open 

		int totalRange = nextInterval + openChanceBase;

		//generate random 
		int tileCheckInt = Random.Range (0, totalRange);

		if (waterChanceArray [0] <= tileCheckInt && tileCheckInt <= waterChanceArray [1]) {
			//water tile
			return 'w';
		} else if (treeChanceArray [0] <= tileCheckInt && tileCheckInt <= treeChanceArray [1]) {
			//tree tile
			return 'T';
		} else if (mtnChanceArray [0] <= tileCheckInt && tileCheckInt <= mtnChanceArray [1]) {
			//mountain tile
			return 'm';
		} else {
			//open (no) tile
			return '_';
		}

	}

	public string createNewMapString() {
		mapString = "";

		for (int i = 0; i < ((rowSize * numberRows)-1); i ++) {

			char c = getRandomMapCharforPos (i);
			mapString = mapString + c;

		}

		return mapString;
	}


}
