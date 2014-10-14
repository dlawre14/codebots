using UnityEngine;
using System.Collections;

public class ClickBlock : MonoBehaviour {

	public Texture t;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			RaycastHit hit;
			if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit, 200.0f)) {
				if (hit.transform.GetComponent<Block>() != null)
					hit.transform.GetComponent<Block>().Hit (t);
			}
		}
	}
}
