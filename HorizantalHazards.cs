﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizantalHazards : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * Time.deltaTime * 1);
	}
}
