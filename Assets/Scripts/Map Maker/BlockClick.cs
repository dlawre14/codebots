﻿using UnityEngine;
using System.Collections;

public class BlockClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter() {
		Debug.Log ("hello I'm " + gameObject.name);
	}
}
