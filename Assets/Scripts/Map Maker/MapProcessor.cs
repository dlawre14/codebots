using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapProcessor : MonoBehaviour {

	public Texture debug;

	public void MakeMap() {
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("Map Block");

		List<string> obj_names = new List<string> ();
		Dictionary<string, int> obj_heights = new Dictionary<string, int> ();
		Dictionary<string, string> obj_colors = new Dictionary<string, string> ();

		foreach (GameObject obj in objs) {
			obj_names.Add(obj.name);
		}

		obj_names.Sort ();

		StartCoroutine (ColorTrack (obj_names));

		//The inner list is a layer
		List<List<string>> maplist = new List<List<string>> ();

		//TODO Output to a map file
	}

	IEnumerator ColorTrack(List<string> obj_names) {
		foreach (string s in obj_names) {
			GameObject.Find (s).GetComponent<BuildingBlock>().color = debug;
			yield return new WaitForSeconds(1);
		}
	}
}
