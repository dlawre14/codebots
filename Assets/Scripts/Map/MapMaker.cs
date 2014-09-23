using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapMaker : MonoBehaviour {

	[Tooltip ("File cotaining map data")]
	public TextAsset map_file;
	[Tooltip ("List of possible textures for blocks")]
	public Texture[] textures;
	[Tooltip ("Block to make...")]
	public GameObject block_prefab;

	private List<GameObject> blocks = new List<GameObject>();


	// Use this for initialization
	void Start () {
		char[] trims = {'(', ')'};

		Vector3 pos = Vector3.zero;

		string[] text = map_file.text.Split ('\n');
		foreach (string s in text) {
			string[] t2 = s.Split (' ');
			foreach (string s2 in t2) {
				string[] t3 = s2.Split (','); //t3[0] is height t3[1] is texture
				pos.x += 1;
				for (int i = 0; i < System.Convert.ToInt32(t3[0].Trim(trims)); i++) {
					blocks.Add ((GameObject) Instantiate(block_prefab, pos, Quaternion.identity));
					pos.y += 1;
				}
				pos.y = 0;
			}
			pos.x = 0;
			pos.z += 1;
		}
	}
}
