using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManeuverHandler : MonoBehaviour {
	
	public GameObject[] Maneuver_objects;
	private List<Maneuver> moves = new List<Maneuver>();
		
	// Update is called once per frame
	void Update () {
		
	}
	
	public void SetMoves() {
		moves.Clear();
		foreach (GameObject g in Maneuver_objects)
			moves.Add (g.GetComponent<Maneuver>());			
	}
	
	//Entirely for debugging
	public void PrintMoves() {
		foreach (Maneuver m in moves)
			Debug.Log (m.name);
	}
}
