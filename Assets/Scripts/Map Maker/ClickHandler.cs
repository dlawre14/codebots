using UnityEngine;
using System.Collections;

public class ClickHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			RaycastHit hit;
			if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit, 200.0f)) {
				hit.collider.SendMessageUpwards("BlockClicked", hit.collider);
			}
		}
	}
}
