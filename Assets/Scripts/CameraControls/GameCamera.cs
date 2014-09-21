using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {
	
	public GameObject map;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.mousePosition.x < 15)
			transform.RotateAround(map.transform.position, Vector3.up, 20 * Time.deltaTime);
		else if (Input.mousePosition.x > Screen.width - 15)
			transform.RotateAround(map.transform.position, Vector3.up, -20 * Time.deltaTime);
			
		if (Input.GetAxis("Mouse ScrollWheel") > 0) {
			transform.Translate(Vector3.forward * Time.deltaTime * 10);
		}
		else if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			transform.Translate(-Vector3.forward * Time.deltaTime * 10);
		}
	}
}
