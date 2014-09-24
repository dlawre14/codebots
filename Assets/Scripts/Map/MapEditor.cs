using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapEditor : MonoBehaviour {

	public GameObject panel;

	public InputField length;
	public InputField width;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		try {
			GetComponent<RectTransform> ().sizeDelta = new Vector2 (10 + System.Convert.ToInt32(width.value) * 25, 10 + System.Convert.ToInt32(length.value) * 25);
			}
		catch (System.FormatException) {	}				
	}

	public void CreateFields() {
		foreach (Transform child in transform) {
			Destroy (child.gameObject);
		}
		for (int i = 0; i < System.Convert.ToInt32(length.value); i++) {
			for (int j = 0; j < System.Convert.ToInt32(width.value); j++) {
					GameObject g = (GameObject)Instantiate (panel);
					g.transform.parent = transform;
			}
		}
	}
}
