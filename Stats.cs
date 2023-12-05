using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://processing.org/tutorials/2darray

//https://stackoverflow.com/questions/4384202/compiler-error-invalid-rank-specifier-expected-or-on-two-dimensional-ar          
[System.Serializable]
public class Stats {

	static int cols = 3;
	static int rows = 5;
	public static string playerScore;
	public static string playerName;
	public static string playerRank;
	public static string[,] statsArray = new string[cols, rows];
}

