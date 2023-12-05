using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


//Reference: https://docs.unity3d.com/Manual/script-InputField.html
public class NameInput : MonoBehaviour {

	public static string playerName;
	public static string[,] defaultStatsArray = new string[3, 5];
	public Text Username_field;

	private PlayerController finalScore;
	private string compare;
	private int compareInt;

	void Start(){
		defaultStatsArray = new string [,] { 	{ "1", "BOB", "100" }, 
												{"2", "LINDA", "32"}, 
												{"3", "TINA", "6"}, 
												{"4", "LOUISE", "3"}, 
												{"5", "GENE", "0"} };
		
		Debug.Log ("Your Score is: " + PlayerController.finalScore);
	}

	public void DisplayName()
	{
		playerName = Username_field.text.ToString();
		//Reference for converting string to int: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number

		/*compare = defaultStatsArray[1,3];
		try
		{
			int result1 = Int32.Parse(compare);
			Debug.Log(result1);
		}
		catch (FormatException)
		{
			Debug.Log("Unable to parse '{defaultStatsArray[1,3]}'");
		}
		if (PlayerController.finalScore > compare){
			defaultStatsArray[1,2] = playerName;
			defaultStatsArray[1,3] = PlayerController.finalScore;
		}

		compare = defaultStatsArray[2,3];
		try
		{
			int result1 = Int32.Parse(compare);
			Debug.Log(result1);
		}
		catch (FormatException)
		{
			Debug.Log("Unable to parse '{defaultStatsArray[2,3]}'");
		}
		if (PlayerController.finalScore > compare){
			defaultStatsArray[2,2] = playerName;
			defaultStatsArray[2,3] = PlayerController.finalScore;
		}

		compare = defaultStatsArray[3,3];
		try
		{
			int result1 = Int32.Parse(compare);
			Debug.Log(result1);
		}
		catch (FormatException)
		{
			Debug.Log("Unable to parse '{defaultStatsArray[3,3]}'");
		}
		if (PlayerController.finalScore > compare){
			defaultStatsArray[3,2] = playerName;
			defaultStatsArray[3,3] = PlayerController.finalScore;
		}

		compare = defaultStatsArray[4,3];
		try
		{
			int result1 = Int32.Parse(compare);
			Debug.Log(result1);
		}
		catch (FormatException)
		{
			Debug.Log("Unable to parse '{defaultStatsArray[4,3]}'");
		}
		if (PlayerController.finalScore > compare){
			defaultStatsArray[4,2] = playerName;
			defaultStatsArray[4,3] = PlayerController.finalScore;
		}

		compare = defaultStatsArray[5,3];
		try
		{
			int result1 = Int32.Parse(compare);
			Debug.Log(result1);
		}
		catch (FormatException)
		{
			Debug.Log("Unable to parse '{defaultStatsArray[5,3]}'");
		}
		if (PlayerController.finalScore > compare){
			defaultStatsArray[5,2] = playerName;
			defaultStatsArray[5,3] = PlayerController.finalScore;
		}*/
	}

	public void Save(){
		File.WriteAllText(Application.dataPath + "/name.txt", playerName);
		Debug.Log("Your name was saved! " + playerName);
	}
	public void Load(){
		if (File.Exists(Application.dataPath + "/name.txt"))
		{  
			//create a single string from the text file
			string loadString = File.ReadAllText(Application.dataPath + "/name.txt");
			Debug.Log ("Your name is: " + playerName);
		}
		else
		{
			Debug.Log("No File");
		}
	}
}
