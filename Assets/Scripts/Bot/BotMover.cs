using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BotMover : MonoBehaviour {

	private Block curr_block;

	public void SetCurrentBlock (Block c) {
		curr_block = c;
	}

	public void MoveForward() {
		if (curr_block.IsMoveValid (Vector3.up)) { //this uses up since the y component of block position is our z axes in world space
			Debug.Log ("Valid move!");
			curr_block = curr_block.GetBlock(Vector3.up);
			transform.position += Vector3.forward; 
		}
	}

	public void MoveBackward() {
		if (curr_block.IsMoveValid (-Vector3.up)) { //this uses up since the y component of block position is our z axes in world space
			Debug.Log ("Valid move!");
			curr_block = curr_block.GetBlock(-Vector3.up);
			transform.position -= Vector3.forward; 
		}
	}
}
