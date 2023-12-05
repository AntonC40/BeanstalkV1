using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour {

	//https://hub.packtpub.com/arrays-lists-dictionaries-unity-3d-game-development/

	List<GameObject> prefabList = new List<GameObject>();
	public GameObject Background1;
	public GameObject Background2;
	public GameObject Background3;
	public GameObject Background4;
	public GameObject Background5;
	int prefabIndex;

	public GameObject topOfBackground;

	void Start(){
		prefabList.Add(Background1);
		prefabList.Add(Background2);
		prefabList.Add(Background3);
		prefabList.Add(Background4);
		prefabList.Add(Background5);
		prefabIndex = UnityEngine.Random.Range (0, 4);
	}

	//This method creates a child gameobject to amke the background appear endless
	//and destroys the parent after 30 seconds
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player"){
			Instantiate (prefabList[prefabIndex], new Vector3 (topOfBackground.transform.position.x, topOfBackground.transform.position.y,
			topOfBackground.transform.position.z), Quaternion.identity);

			Destroy(transform.parent.gameObject, 30);
		}
	}
}
