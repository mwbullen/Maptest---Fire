using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class MapInfo
{
	public string mapSourceString;
	//public System.Collections.Generic.List<int> visibleTiles = new System.Collections.Generic.List<int> ();
	//public System.Collections.Generic.List<int> foodTiles = new System.Collections.Generic.List<int>();

	public Hashtable visibleTiles = new  Hashtable ();
	public Hashtable foodTiles = new Hashtable();

	public int rowSize;
	public int numberRows;

	public MapInfo (string newMapString, int newMapRowSize, int newMapNumberRows)
	{
		mapSourceString = newMapString;
		rowSize = newMapRowSize;
		numberRows = newMapNumberRows;
	}

	public char getTileStringatPosition(int position) {
		if (position > 0) {
			//return mapDefinition [position].ToString();
			return mapSourceString[position];
		} else {
			return ' ';
		}
	}


}


