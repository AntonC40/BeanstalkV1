using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelCotroller : MonoBehaviour {

	public void LoadLevel(int sceneNumber){
		SceneManager.LoadScene(sceneNumber);
	}

}
