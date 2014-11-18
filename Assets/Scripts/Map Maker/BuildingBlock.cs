using UnityEngine;
using System.Collections;

public class BuildingBlock : MonoBehaviour {


	public Vector3 position;

	public GameObject block;
	public Texture color;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		renderer.material.mainTexture = color;
	}

	void BlockClicked(Collider c) {
		if (c.name == "Top") {
			BuildingBlock b = ((GameObject)Instantiate (block, position + Vector3.up, Quaternion.identity)).GetComponent<BuildingBlock>();
			b.position = position + Vector3.up;
			b.color = color;
			b.gameObject.name = "(" + b.position.x + "," + b.position.y + "," + b.position.z + ")";
		}

		if (c.name == "Bottom" && position.y > 0) {
			BuildingBlock b = ((GameObject)Instantiate (block, position - Vector3.up, Quaternion.identity)).GetComponent<BuildingBlock>();
			b.position = position - Vector3.up;
			b.color = color;
			b.gameObject.name = "(" + b.position.x + "," + b.position.y + "," + b.position.z + ")";
		}

		if (c.name == "South") {
			BuildingBlock b = ((GameObject)Instantiate (block, position + Vector3.right, Quaternion.identity)).GetComponent<BuildingBlock>();
			b.position = position + Vector3.right;
			b.color = color;
			b.gameObject.name = "(" + b.position.x + "," + b.position.y + "," + b.position.z + ")";
		}

		if (c.name == "East") {
			BuildingBlock b = ((GameObject)Instantiate (block, position + Vector3.forward, Quaternion.identity)).GetComponent<BuildingBlock>();
			b.position = position + Vector3.forward;
			b.color = color;
			b.gameObject.name = "(" + b.position.x + "," + b.position.y + "," + b.position.z + ")";
		}

		if (c.name == "West" && position.z > 0) {
			BuildingBlock b = ((GameObject)Instantiate (block, position - Vector3.forward, Quaternion.identity)).GetComponent<BuildingBlock>();
			b.position = position - Vector3.forward;
			b.color = color;
			b.gameObject.name = "(" + b.position.x + "," + b.position.y + "," + b.position.z + ")";
		}

		if (c.name == "North" && position.x > 0) {
			BuildingBlock b = ((GameObject)Instantiate (block, position - Vector3.right, Quaternion.identity)).GetComponent<BuildingBlock>();
			b.position = position - Vector3.right;
			b.color = color;
			b.gameObject.name = "(" + b.position.x + "," + b.position.y + "," + b.position.z + ")";
		}
	}

	void BlockRightClicked() {
		Debug.Log ("Right clicked!");
	}
}
