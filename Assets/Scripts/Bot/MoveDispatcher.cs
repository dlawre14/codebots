using UnityEngine;
using System.Collections;

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
}
