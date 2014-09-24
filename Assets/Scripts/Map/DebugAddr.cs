using UnityEngine;
using System.Collections;

public class DebugAddr : MonoBehaviour {

	public GameObject panel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddPanel() {
		GameObject g = (GameObject) Instantiate (panel);
		g.transform.parent = transform;
	}
}
