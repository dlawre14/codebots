using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {
	
	public GameObject bot;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.A))
			transform.RotateAround(bot.transform.position, Vector3.up, 30 * Time.deltaTime);
		else if (Input.GetKey(KeyCode.D))
			transform.RotateAround(bot.transform.position, Vector3.up, -30 * Time.deltaTime);
			
		if (Input.GetKey(KeyCode.W)) {
			transform.Translate(Vector3.forward * Time.deltaTime * 5);
		}
		else if (Input.GetKey(KeyCode.S)) {
			transform.Translate(-Vector3.forward * Time.deltaTime * 5);
		}
	}
}
