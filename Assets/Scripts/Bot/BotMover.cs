using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BotMover : MonoBehaviour {
	
	public static float ROTATION_TIME = 1.5f;
	
	[Tooltip ("The object that contains the ManeuverHandler")]
	public GameObject handler;
	
	private Maneuver[] moves = new Maneuver[ManeuverHandler.NUM_MOVES];
	
	public void PerformMoves() {
		Debug.Log ("Starting turn");
		StartCoroutine(MoveCoroutine());
	}
	
	public void LoadMoves(Maneuver[] mov) {
		for (int i = 0; i < ManeuverHandler.NUM_MOVES; i++)
			moves[i] = mov[i];		
	}
	
	//This is here to facilitate waiting
	IEnumerator MoveCoroutine() {
		foreach (Maneuver m in moves) {
			Debug.Log ("Move is: " + m.name);
			if (m.move_type == Maneuver.MoveTypes.forward) {
				Dictionary<string, float> mods = m.modifiers;
				for (float i = 0; i < mods["duration"]; i+=Time.deltaTime) {
					Debug.Log ("Spinning...");
					rigidbody.AddForce (transform.forward * Time.deltaTime * mods["speed"]);
					yield return new WaitForSeconds(0);
				}
				rigidbody.velocity = Vector3.zero;
			}
			else if (m.move_type == Maneuver.MoveTypes.reverse) {
				Dictionary<string, float> mods = m.modifiers;
				for (float i = 0; i < mods["duration"]; i+=Time.deltaTime) {
					Debug.Log ("Spinning...");
					rigidbody.AddForce ((-1) * transform.forward * Time.deltaTime * mods["speed"]);
					yield return new WaitForSeconds(0);
				}
				rigidbody.velocity = Vector3.zero;
			}
			else if (m.move_type == Maneuver.MoveTypes.left_turn) {
				Dictionary<string, float> mods = m.modifiers;
				for (float i = 0; i < ROTATION_TIME; i+=Time.deltaTime) {
					transform.Rotate(new Vector3(0, (-1) * mods["degree"] * Time.deltaTime, 0));
					yield return new WaitForSeconds(0);
				}
			}		
			else if (m.move_type == Maneuver.MoveTypes.right_turn) {
				Dictionary<string, float> mods = m.modifiers;
				for (float i = 0; i < ROTATION_TIME; i+=Time.deltaTime) {
					transform.Rotate(new Vector3(0, mods["degree"] * Time.deltaTime, 0));
					yield return new WaitForSeconds(0);
				}
			}	
			yield return new WaitForSeconds(0);
		}
	}
}
