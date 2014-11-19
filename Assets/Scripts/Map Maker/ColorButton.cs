using UnityEngine;
using System.Collections;

public class ColorButton : MonoBehaviour {

	public Texture color;
	public GameObject target;

	public void ColorTarget() {
		target.GetComponent<BuildingBlock> ().color = color;
	}
}
