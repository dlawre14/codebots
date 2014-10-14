using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MoveDispatcher : MonoBehaviour {

	public enum moves {
		forward,reverse,left,right
	}

	public void DispatchMoveForward () {
		GameObject.Find ("Bot(Clone)").GetComponent<BotMover>().MoveForward();
		GameObject.Find ("Output Log").GetComponent<Text>().text += (System.DateTime.Now + " -- Handling move: Forward" + "\n");
	}

	public void DispatchMoveBackward () {
		GameObject.Find ("Bot(Clone)").GetComponent<BotMover>().MoveBackward();
		GameObject.Find ("Output Log").GetComponent<Text>().text += (System.DateTime.Now + " -- Handling move: Backward" + "\n");
	}

	public void DispatchMoveLeft() {
		GameObject.Find ("Bot(Clone)").GetComponent<BotMover>().MoveLeft();
		GameObject.Find ("Output Log").GetComponent<Text>().text += (System.DateTime.Now + " -- Handling move: Left" + "\n");
	}

	public void DispatchMoveRight() {
		GameObject.Find ("Bot(Clone)").GetComponent<BotMover>().MoveRight();
		GameObject.Find ("Output Log").GetComponent<Text>().text += (System.DateTime.Now + " -- Handling move: Right" + "\n");
	}

	public void DispatchSubroutine(TextAsset input) {
		Parser p = new Parser();
		List<string> moves = p.Parse (input.text);
		Debug.Log ("Dispatching moves...");
		StartCoroutine (SubroutineDispatcher(moves));
	}

	public void DispatchSubroutine(InputField input) {
		Parser p = new Parser();
		List<string> moves = p.Parse (input.value);
		StartCoroutine (SubroutineDispatcher(moves));
		input.value = "";
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
