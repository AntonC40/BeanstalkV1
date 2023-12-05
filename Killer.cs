using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Killer : MonoBehaviour {
	
	//Script attached to trigger death win the player falls and destroy item prefabs
	//Reference: https://answers.unity.com/questions/1077612/destroy-other-objects-on-collision-unity.html
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") {
			SceneManager.LoadScene (3);
		}
		Destroy (col.gameObject);
		Debug.Log ("Item destroyed");
	}
}
