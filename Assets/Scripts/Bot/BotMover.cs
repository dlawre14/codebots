using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BotMover : MonoBehaviour {

	private Block curr_block;

	private enum direction {
		north, south, east, west
	}

	private direction dir = direction.north;

	void Update() {
		Debug.DrawRay (transform.position, transform.forward, Color.yellow);
		Debug.DrawRay (curr_block.transform.position, curr_block.transform.up * 5.0f, Color.cyan);
	}

	public void SetCurrentBlock (Block c) {
		curr_block = c;
	}

	public void MoveForward() {
		switch(dir) {
			case direction.north:
				if (curr_block.IsMoveValid (Vector3.up)) { //this uses up since the y component of block position is our z axes in world space
					//Debug.Log ("Valid move!");
					curr_block = curr_block.GetBlock(Vector3.up);
					transform.position += transform.forward; 
				}
				break;
			case direction.south:
				if (curr_block.IsMoveValid (-Vector3.up)) { //this uses up since the y component of block position is our z axes in world space
					//Debug.Log ("Valid move!");
					curr_block = curr_block.GetBlock(-Vector3.up);
					transform.position += transform.forward; 
				}
				break;
			case direction.east:
				if (curr_block.IsMoveValid (Vector3.right)) { //this uses up since the y component of block position is our z axes in world space
					//Debug.Log ("Valid move!");
					curr_block = curr_block.GetBlock(Vector3.right);
					transform.position += transform.forward; 
				}
				break;
			case direction.west:
				if (curr_block.IsMoveValid (-Vector3.right)) { //this uses up since the y component of block position is our z axes in world space
					//Debug.Log ("Valid move!");
					curr_block = curr_block.GetBlock(-Vector3.right);
					transform.position += transform.forward; 
				}
				break;
			}
	}

	public void MoveBackward() {
		switch(dir) {
		case direction.north:
			if (curr_block.IsMoveValid (-Vector3.up)) { //this uses up since the y component of block position is our z axes in world space
				//Debug.Log ("Valid move!");
				curr_block = curr_block.GetBlock(-Vector3.up);
				transform.position -= transform.forward; 
			}
			break;
		case direction.south:
			if (curr_block.IsMoveValid (Vector3.up)) { //this uses up since the y component of block position is our z axes in world space
				//Debug.Log ("Valid move!");
				curr_block = curr_block.GetBlock(Vector3.up);
				transform.position -= transform.forward; 
			}
			break;
		case direction.east:
			if (curr_block.IsMoveValid (-Vector3.right)) { //this uses up since the y component of block position is our z axes in world space
				//Debug.Log ("Valid move!");
				curr_block = curr_block.GetBlock(-Vector3.right);
				transform.position -= transform.forward; 
			}
			break;
		case direction.west:
			if (curr_block.IsMoveValid (Vector3.right)) { //this uses up since the y component of block position is our z axes in world space
				//Debug.Log ("Valid move!");
				curr_block = curr_block.GetBlock(Vector3.right);
				transform.position -= transform.forward; 
			}
			break;
		}
	}

	public void MoveLeft() { //still needs to handle all the movements
		switch(dir) {
			case direction.north:
				if (curr_block.IsMoveValid (Vector3.up)) {
					curr_block = curr_block.GetBlock (Vector3.up);
					transform.position += transform.forward;
					transform.Rotate(0, -90, 0);
					dir = direction.west;
					MoveForward();
				}
				else {
					transform.Rotate(0, -90, 0);
					dir = direction.west;
				}
				break;
			case direction.south:
				if (curr_block.IsMoveValid (-Vector3.up)) {
					curr_block = curr_block.GetBlock (-Vector3.up);
					transform.position += transform.forward;
					transform.Rotate(0, -90, 0);
					dir = direction.east;
					MoveForward();
				}
				else {
					transform.Rotate(0, -90, 0);
					dir = direction.east;
				}
				break;
			case direction.east:
				if (curr_block.IsMoveValid (Vector3.right)) {
					curr_block = curr_block.GetBlock (Vector3.right);
					transform.position += transform.forward;
					transform.Rotate(0, -90, 0);
					dir = direction.north;
					MoveForward();
				}
				else {
					transform.Rotate(0, -90, 0);
					dir = direction.north;
				}
				break;
			case direction.west:
				if (curr_block.IsMoveValid (-Vector3.right)) {
					curr_block = curr_block.GetBlock (-Vector3.right);
					transform.position += transform.forward;
					transform.Rotate(0, -90, 0);
					dir = direction.south;
					MoveForward();
				}
				else {
					transform.Rotate(0, -90, 0);
					dir = direction.south;
				}
				break;
		}
	}

	public void MoveRight() {
		switch(dir) {
		case direction.north:
			if (curr_block.IsMoveValid (Vector3.up)) {
				curr_block = curr_block.GetBlock (Vector3.up);
				transform.position += transform.forward;
				transform.Rotate(0, 90, 0);
				dir = direction.east;
				MoveForward();
			}
			else {
				transform.Rotate(0, 90, 0);
				dir = direction.east;
			}
			break;
		case direction.south:
			if (curr_block.IsMoveValid (-Vector3.up)) {
				curr_block = curr_block.GetBlock (-Vector3.up);
				transform.position += transform.forward;
				transform.Rotate(0, 90, 0);
				dir = direction.west;
				MoveForward();
			}
			else {
				transform.Rotate(0, 90, 0);
				dir = direction.west;
			}
			break;
		case direction.east:
			if (curr_block.IsMoveValid (Vector3.right)) {
				curr_block = curr_block.GetBlock (Vector3.right);
				transform.position += transform.forward;
				transform.Rotate(0, 90, 0);
				dir = direction.south;
				MoveForward();
			}
			else {
				transform.Rotate(0, 90, 0);
				dir = direction.south;
			}
			break;
		case direction.west:
			if (curr_block.IsMoveValid (-Vector3.right)) {
				curr_block = curr_block.GetBlock (-Vector3.right);
				transform.position += transform.forward;
				transform.Rotate(0, 90, 0);
				dir = direction.north;
				MoveForward();
			}
			else {
				transform.Rotate(0, 90, 0);
				dir = direction.north;
			}
			break;
		}
	}
}
