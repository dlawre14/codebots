using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapMaker : MonoBehaviour {

	[Tooltip ("Block to make...")]
	public GameObject block_prefab;

	private List<GameObject> blocks = new List<GameObject>();

	private static char[] delims = {',', '(', ')'};
	
	// Use this for initialization
	public void BuildMap (string[] map) {
		foreach (Transform t in transform)
			Destroy (t.gameObject);
		Vector3 pos = Vector3.zero;
		foreach (string s in map) {
			string[] coords = s.Split(' ');
			foreach (string coord in coords) {
				if (coord != "") {
					string[] nums = coord.Split(delims);
					for (int i = 0; i < System.Convert.ToInt32(nums[1]); i++) {
						//Needs texture stuff later
						GameObject g = (GameObject) Instantiate (block_prefab, pos, Quaternion.identity);
						g.transform.parent = transform;
						pos.y += 1;
					}
				}
			pos.y = 0;
		 	pos.x += 1;
			}
		pos.x = 0;
		pos.z += 1;	
		}
	}
}
