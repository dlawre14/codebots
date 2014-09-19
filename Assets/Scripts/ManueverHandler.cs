using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManueverHandler : MonoBehaviour {
	
	public GameObject[] manuever_objects;
	private List<Manuever> moves = new List<Manuever>();
		
	// Update is called once per frame
	void Update () {
		
	}
	
	public void SetMoves() {
		moves.Clear();
		foreach (GameObject g in manuever_objects)
			moves.Add (g.GetComponent<Manuever>());			
	}
	
	//Entirely for debugging
	public void PrintMoves() {
		foreach (Manuever m in moves)
			Debug.Log (m.name);
	}
}
