using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	public Texture texture;
	public bool spawn;

	private Block[,,] map;
	private Vector3 pos;

	public Vector3 position {
		get {
			return pos;
		}
	}

	private bool istop;
	public bool isTop {
		get {
			return istop;
		}
	}

	// Use this for initialization
	void Start () {
		gameObject.renderer.material.mainTexture = texture;
	}

	public void SetPos(Vector3 p) {
		pos = p;
	}

	public void SetMap(Block[,,] m) {
		map = m;

		//prep work for block
		if (map [(int)pos.x, (int)pos.y, (int)pos.z + 1] != null)
			istop = false;
		else
			istop = true;

		//Debug.Log ("The block at " + pos + "has top value..." + isTop);
	}

	//We check if where we want to move is valid, assume mov components are at most 1 and at least -1
	public bool IsMoveValid(Vector3 mov) {
		if (pos.x + mov.x < 0 || pos.y + mov.y < 0 || pos.z + mov.z < 0) {
			return false;
		}

		if (pos.x + mov.x > 50 || pos.y + mov.y > 50 || pos.z + mov.z > 50) {
			return false;
		}

		if (map[(int)pos.x + (int)mov.x, (int)pos.y + (int)mov.y, (int)pos.z + (int)mov.z] != null) {
			if (map[(int)pos.x + (int)mov.x, (int)pos.y + (int)mov.y, (int)pos.z + (int)mov.z].isTop) {
				return true;
			}
			else
				return false;
		}
		else
			return false;
	}

	public Block GetBlock(Vector3 mov) {
		if (map[(int)pos.x + (int)mov.x, (int)pos.y + (int)mov.y, (int)pos.z + (int)mov.z] == null) {
			Debug.LogError ("Tried to grab a non-existant block...");
			return null;
		}
		else {
			return map[(int)pos.x + (int)mov.x, (int)pos.y + (int)mov.y, (int)pos.z + (int)mov.z];
		}
	}

	public void UpdateTexture(Texture t) {
		texture = t;
		gameObject.renderer.material.mainTexture = texture;
	}

	public void Hit(Texture t) {
		if (gameObject.renderer.material.mainTexture == texture)
			gameObject.renderer.material.mainTexture = t;
		else
			gameObject.renderer.material.mainTexture = texture;
	}
}
