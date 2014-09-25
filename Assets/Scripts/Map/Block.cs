using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	public Texture texture;
	public bool spawn;

	// Use this for initialization
	void Start () {
		gameObject.renderer.material.mainTexture = texture;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
