﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorPopup : MonoBehaviour {

	public string[] labels;
	public Texture[] colors;

	public GameObject panel;
	public GameObject button;

	public GameObject target;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < labels.Length; i++) {
			GameObject g = (GameObject) Instantiate(button, Vector3.zero, Quaternion.identity);
			g.transform.parent = panel.transform;

			g.GetComponentInChildren<Text>().text = labels[i];
			ColorButton cb = g.GetComponent<ColorButton>();
			cb.color = colors[i];
			cb.target = target;
		}

	}
	
	public void ColorPicked() {
		Destroy (gameObject);
	}
}
