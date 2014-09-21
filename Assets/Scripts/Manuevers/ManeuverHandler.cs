using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ManeuverHandler : MonoBehaviour {
	
	public static int NUM_MOVES = 5;
	
	public GameObject outbox;
	
	public GameObject[] maneuver_objects;
	private Maneuver[] moves = new Maneuver[NUM_MOVES];
	
	public void SetMoves() {
		for (int i = 0; i<NUM_MOVES; i++) {
			moves[i] = maneuver_objects[i].GetComponent<Maneuver>();
		} 
	}
	
	//Entirely for debugging
	public void PrintMoves() {
		string boxtext = "Move Output:\n---\n";
		for (int i = 0; i<NUM_MOVES; i++) {
			string modstring = "";
			foreach (KeyValuePair<string, float> entry in moves[i].modifiers) {
				modstring += entry.Key + ": " + entry.Value.ToString ("#.##") + " ";
			}
			boxtext += "Turn " + (i+1) + " bot performed: " + moves[i].name + " :: " + modstring + "\n";
		}
		outbox.GetComponent<Text>().text = boxtext;
	}
	
	public void DoMoves() {
		//Assume one bot for now
		BotMover bot = GameObject.Find ("Bot").GetComponent<BotMover>();
		bot.LoadMoves(moves);
		bot.PerformMoves();
	}
}
