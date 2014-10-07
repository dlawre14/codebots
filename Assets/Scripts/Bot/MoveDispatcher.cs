using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveDispatcher : MonoBehaviour {

	public enum moves {
		forward,reverse,left,right
	}

	public void DispatchMoveForward () {
		GameObject.Find ("Bot(Clone)").GetComponent<BotMover>().MoveForward();
	}

	public void DispatchMoveBackward () {
		GameObject.Find ("Bot(Clone)").GetComponent<BotMover>().MoveBackward();
	}

	public void DispatchMoveLeft() {
		GameObject.Find ("Bot(Clone)").GetComponent<BotMover>().MoveLeft();
	}

	public void DispatchMoveRight() {
		GameObject.Find ("Bot(Clone)").GetComponent<BotMover>().MoveRight();
	}

	public void DispatchSubroutine(TextAsset input) {
		Parser p = new Parser();
		List<string> moves = p.Parse (input.text);
		Debug.Log ("Dispatching moves...");
		StartCoroutine (SubroutineDispatcher(moves));
	}

	IEnumerator SubroutineDispatcher(List<string> moves) {
		foreach (string s in moves) {
			Debug.Log ("Handling move: " + s);
			if (s == "FWD") {
				DispatchMoveForward();
			}
			else if (s == "BWD") {
				DispatchMoveBackward();
            }
			else if (s == "LFT") {
				DispatchMoveLeft();
            }
			else if (s == "RGT") {
				DispatchMoveRight();
            }
			yield return new WaitForSeconds(1);
        }
    }
}
