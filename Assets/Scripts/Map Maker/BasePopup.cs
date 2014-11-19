using UnityEngine;
using System.Collections;

public class BasePopup : MonoBehaviour {

	public GameObject colorPop;

	public GameObject target;

	public void DeleteTarget() {
		if (target.transform.position != Vector3.zero) {
			Destroy (target);
			Destroy (gameObject);
		}
	}

	public void ColorMenu() {
		//Create color menu
		GameObject p = (GameObject) Instantiate (colorPop, transform.position, Quaternion.identity);
		
		p.transform.parent = GameObject.Find ("Canvas").transform;
		p.GetComponent<ColorPopup> ().target = target;

		Destroy (gameObject);
	}
}
