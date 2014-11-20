using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class MapProcessor : MonoBehaviour {

	public Texture debug;

	public void MakeMap() {
		if (Application.platform == RuntimePlatform.WindowsWebPlayer)
			return;

		GameObject[] objs = GameObject.FindGameObjectsWithTag ("Map Block");

		List<string> obj_names = new List<string> ();
		Dictionary<string, int> obj_heights = new Dictionary<string, int> ();
		Dictionary<string, string> obj_colors = new Dictionary<string, string> ();

		foreach (GameObject obj in objs) {
			obj_names.Add(obj.name);
		}

		obj_names.Sort ();

		//StartCoroutine (ColorTrack (obj_names));

		//The inner list is a layer
		List<string> maplist = new List<string> ();

		for (int i = 0; i < 50; i++) { //this is a layer, i.e. vertical
			maplist.Add("{\n");
			for (int j = 0; j < 50; j++) { //this is the column adjust of a layer
				for (int k = 0; k < 50; k++) { //this is a row in a layer
					GameObject g = GameObject.Find ("(" + k + "," + i + "," + j + ")");
					if (g != null) {
						maplist[maplist.Count - 1] += "(" + g.GetComponent<BuildingBlock>().color.name + ")";
					}
					else {
						maplist[maplist.Count - 1] += "(0)";
					}
				}
				maplist[maplist.Count -1] += "\n";
			}
			maplist[maplist.Count -1] += "}\n";
		}

		StreamWriter writer = new StreamWriter ("Assets/Maps/New Style/testmap.txt");
		foreach (string s in maplist) {
			writer.Write(s);
		}
		writer.Close ();
	}

	IEnumerator ColorTrack(List<string> obj_names) {
		foreach (string s in obj_names) {
			GameObject.Find (s).GetComponent<BuildingBlock>().color = debug;
			Debug.Log ("Colored: " + s);
			yield return new WaitForSeconds(1);
		}
	}
}
