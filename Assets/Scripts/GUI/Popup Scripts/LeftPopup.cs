using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LeftPopup : MonoBehaviour {

	private float[] mods = new float[1]; //0 is time, 1 is speed
	
	private GameObject creator;
	private Maneuver parent_maneuver;
	
	private Slider degree_bar;
	
	void Start() {
		degree_bar = transform.Find ("Degree Slider").GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
		mods[0] = degree_bar.value;
		
		parent_maneuver.mod_string = "Deg: " + mods[0];
		
		parent_maneuver.ChangeModifier("degree", mods[0]);
	}
	
	//Will be used for setting some pointers and things
	public void Init(GameObject c, Maneuver parent) {
		creator = c;
		parent_maneuver = parent;
		
		transform.parent.Find ("Test Maneuvers").GetComponent<Button>().interactable = false;
	}
	
	public void OnCancel() {
		creator.GetComponent<DropMe>().receivingImage.overrideSprite = null;
		creator.GetComponent<Maneuver>().reset();
		
		creator.GetComponentInChildren<Text>().text = "Place Move";
		
		transform.parent.Find ("Test Maneuvers").GetComponent<Button>().interactable = true;
		Destroy (gameObject);
	}
	
	public void OnOk() {
		creator.GetComponent<Maneuver>().clone(parent_maneuver);
		creator.GetComponentInChildren<Text>().text = parent_maneuver.name + "\n" + parent_maneuver.mod_string;
		
		transform.parent.Find ("Test Maneuvers").GetComponent<Button>().interactable = true;
		Destroy (gameObject);
	}
	
}
