using UnityEngine;
using System.Collections;

public class Maneuver : MonoBehaviour {
	
	//Public primarily for debugging
	public string name;
	
	public enum MoveTypes {
		forward, reverse, left_turn, right_turn
	}
	
	[Tooltip ("Select the type of maneuver this object represents")]
	public MoveTypes move_type;
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void clone(Maneuver other) {
		name = other.name;
		move_type = other.move_type;
	}
}
