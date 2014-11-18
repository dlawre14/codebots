using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapProcessor : MonoBehaviour {

	public void MakeMap() {
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("Map Block");

		List<string> obj_names = new List<string> ();
		Dictionary<string, int> obj_heights = new Dictionary<string, int> ();
		Dictionary<string, string> obj_colors = new Dictionary<string, string> ();

		foreach (GameObject obj in objs) {
			obj_names.Add(obj.name);
		}

		obj_names.Sort ();

		char[] delims = {'(',')',','};
		string prev_xz = "";

		foreach (string s in obj_names) {
			string[] temp = s.Split(delims);
			List<string> tokens = new List<string>();

			foreach (string s2 in temp) {
				if (s2 != " " && s2 != "")
					tokens.Add (s2);
			}

			if (!obj_heights.ContainsKey(tokens[0] + "," + tokens[2]))
				obj_heights.Add (tokens[0] + "," + tokens[2], 1);
			else
				obj_heights[tokens[0] + "," + tokens[2]] += 1;

			if (tokens[1] == "0")
				obj_colors.Add (tokens[0] + "," + tokens[2], GameObject.Find ("(" + tokens[0] + "," + tokens[1] + "," + tokens[2] + ")").GetComponent<BuildingBlock>().color.name);
		}

		//TODO Output to a map file
	}

}
