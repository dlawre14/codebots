using UnityEngine;
using System.Collections;

public class Manuever : MonoBehaviour {
	
	//Public primarily for debugging
	public string name;
	
	public enum MoveTypes {
		forward, reverse, left_turn, right_turn
	}
	
	public MoveTypes move_type;
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void clone(Manuever other) {
		name = other.name;
		move_type = other.move_type;
	}
}
