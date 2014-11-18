using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W)) {
			transform.Translate(Vector3.forward * Time.deltaTime * 5);
		}
		if (Input.GetKey(KeyCode.S)) {
			transform.Translate(-Vector3.forward * Time.deltaTime * 5);
		}
		if (Input.GetKey(KeyCode.D)) {
			transform.Translate(Vector3.right * Time.deltaTime * 5);
		}
		if (Input.GetKey(KeyCode.A)) {
			transform.Translate(-Vector3.right* Time.deltaTime * 5);
		}
		if (Input.GetKey(KeyCode.Space)) {
			transform.Translate(Vector3.up* Time.deltaTime * 5);
		}
		if (Input.GetKey(KeyCode.LeftControl)) {
			transform.Translate(-Vector3.up* Time.deltaTime * 5);
		}
		if (Input.GetKey(KeyCode.E)) {
			transform.Rotate(Vector3.up * Time.deltaTime * 45);
		}
		if (Input.GetKey(KeyCode.Q)) {
			transform.Rotate(-Vector3.up * Time.deltaTime * 45);
		}
	}
}
