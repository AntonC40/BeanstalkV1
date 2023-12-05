using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	
	public GameObject player;
	
	// Update is called once per frame
	void Update () {
		player = GameObject.Find("Player"); 
		//Obtains player position
		transform.position = new Vector3(0.0f, player.transform.position.y, -1.0f);
		//Updates camera y position while keeping the x and z positions constant, updating each frame makes it a little bit choppy consider revising
	}
}
