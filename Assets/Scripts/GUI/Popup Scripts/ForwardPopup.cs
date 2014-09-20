using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ForwardPopup : MonoBehaviour {
	
	private float[] mods = new float[2]; //0 is time, 1 is speed
	
	private GameObject creator;
	private Maneuver parent_maneuver;
	
	private Slider time_bar;
	private Slider speed_bar;
	
	private string slot;
	
	void Start() {
		time_bar = transform.Find ("Duration Slider").GetComponent<Slider>();
		speed_bar = transform.Find ("Speed Slider").GetComponent<Slider>();
	}
		
	// Update is called once per frame
	void Update () {
		mods[0] = time_bar.value;
		mods[1] = speed_bar.value;
		
		parent_maneuver.mod_string = "T: " + mods[0].ToString("#.##") + "\nSp: " + mods[1].ToString("#.##");
		
		parent_maneuver.ChangeModifier("duration", mods[0]);
		parent_maneuver.ChangeModifier("speed", mods[1]);
	}
	
	//Will be used for setting some pointers and things
	public void Init(GameObject c, Maneuver parent) {
		creator = c;
		parent_maneuver = parent;
		slot = creator.GetComponentInChildren<Text>().text;
		
		transform.parent.Find ("Test Maneuvers").GetComponent<Button>().interactable = false;
	}
	
	public void OnCancel() {
		creator.GetComponent<DropMe>().receivingImage.overrideSprite = null;
		creator.GetComponent<Maneuver>().reset();
		
		creator.GetComponentInChildren<Text>().text = slot;
		
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
