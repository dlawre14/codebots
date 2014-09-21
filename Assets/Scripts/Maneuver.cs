using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Maneuver : MonoBehaviour {
	
	//Public primarily for debugging
	public string name;
	
	public string mod_string;
	
	public enum MoveTypes {
		forward, reverse, left_turn, right_turn
	}
	
	[Tooltip ("Select the type of maneuver this object represents")]
	public MoveTypes move_type;
	
	[Tooltip ("The popup menu to modify the command")]
	public GameObject popup;
	
	public Dictionary<string, float> modifiers = new Dictionary<string, float>(); //this is for modifiers like speed or turning
	
	public void reset() {
		name = null;
		move_type = MoveTypes.forward;
		popup = null;
	}
	
	public void clone(Maneuver other) {
		name = other.name;
		mod_string = other.mod_string;
		move_type = other.move_type;
		
		modifiers = new Dictionary<string, float>(other.modifiers);
	}
	
	public void ChangeModifier(string mod_name, float value) {
		if (modifiers.ContainsKey(mod_name)) {
			modifiers[mod_name] = value;
		}
		else {
			modifiers.Add (mod_name, value);
		}
	}
	
	public void MakePopup(GameObject creator, Maneuver parent) {
		if (move_type == MoveTypes.forward || move_type == MoveTypes.reverse) {
			GameObject g = (GameObject) Instantiate (popup);
			g.transform.parent = transform.parent;
			g.GetComponent<RectTransform>().localPosition = Vector3.zero;
			g.GetComponent<RectTransform>().localScale = Vector3.one;
			ForwardPopup fp = g.GetComponent<ForwardPopup>();
			fp.Init(creator, parent);
		}
		else if (move_type == MoveTypes.left_turn || move_type == MoveTypes.right_turn) {
			GameObject g = (GameObject) Instantiate (popup);
			g.transform.parent = transform.parent;
			g.GetComponent<RectTransform>().localPosition = Vector3.zero;
			g.GetComponent<RectTransform>().localScale = Vector3.one;
			LeftPopup fp = g.GetComponent<LeftPopup>();
			fp.Init(creator, parent);
		}
	}
}
