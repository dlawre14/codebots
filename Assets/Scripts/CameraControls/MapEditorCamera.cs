using UnityEngine;
using System.Collections;

public class MapEditorCamera : MonoBehaviour {
	
	private float cam_angle = 0;
	private bool mouseEnabled;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (!FindObjectOfType<Canvas>().GetComponent<Panel>().open && mouseEnabled) {
			if (Input.GetAxis ("Mouse X") != 0) {
				transform.Rotate (0, Input.GetAxis ("Mouse X"), 0);
			}
			
			cam_angle = Mathf.Clamp(cam_angle - Input.GetAxis ("Mouse Y"), -90, 90);
			transform.eulerAngles  = new Vector3 (cam_angle, transform.eulerAngles.y, 0);
			
			transform.Translate (Input.GetAxis ("Horizontal") * Time.deltaTime * 10, 0, Input.GetAxis ("Vertical") * Time.deltaTime * 10);
			
		}
		
		if (Input.GetKeyDown (KeyCode.Return) && !FindObjectOfType<Canvas>().GetComponent<Panel>().open) {
			mouseEnabled = !mouseEnabled;
			Screen.lockCursor = !Screen.lockCursor;
		}
	}
}
