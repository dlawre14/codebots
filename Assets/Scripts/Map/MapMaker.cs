using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapMaker : MonoBehaviour {

	[Tooltip ("Block to make...")]
	public GameObject block_prefab;
	public TextAsset map_file;

	private bool comp = false;
	public bool complete {
		get {
			return comp;
			//testing
		}
	}

	public List<string> texture_names;
	public List<Texture> textures;
	
	private Block[,,] blocks;

	// Use this for initialization

	#region old_version
	/*
	void Start () {
				string text = map_file.text;
				string[] lines = text.Split ('\n');
				int width = lines.Length;
				int length = lines [0].Split (' ').Length;

				blocks = new Block[width, length, 25]; //assume no stack is taller than 25
				Vector3 pos = Vector3.zero;

				foreach (string line in lines) {
						string[] vals = line.Split (delims);
						List<string> parsed = new List<string>();
						foreach (string val in vals) {
							if (val != "" && val != ",") {
								//Debug.Log ("adding val: " + val);
								parsed.Add (val);
							}
						}
							while (parsed.Count > 0) {
								for (int i = 0; i < System.Convert.ToInt32(parsed[0]); i++) {
									GameObject g = (GameObject)Instantiate (block_prefab, pos, Quaternion.identity);
									g.transform.parent = transform;
									blocks [(int)pos.x, (int)pos.z, (int)pos.y] = g.GetComponent<Block> ();
									if (texture_names.FindIndex (str => str == parsed[1]) > -1) {
									int z = texture_names.FindIndex(str => str == parsed[1]);
									//Debug.Log(parsed[1] + " is at " + z);
										blocks [(int)pos.x, (int)pos.z, (int)pos.y].UpdateTexture (textures[z]);
									}
									pos.y += 1;
								}
								pos.y = 0;
								pos.z += 1;
								parsed.RemoveAt (0);
								parsed.RemoveAt (0);
								}
										pos.z = 0;
										pos.x += 1;
								}

				//start at 1 end at width/length -1 to ignore the walls, assume height 25 is a ceiling
		for (int i=1; i<width-1; i++) {
			for (int j=1; j<length-1; j++) {
				for (int k=0; k<24;k++) {
					if (blocks[i,j,k] != null) {
						blocks[i,j,k].SetPos (new Vector3 (i,j,k));
						blocks[i,j,k].SetMap (blocks);
					}
				}
			}
		}

		//for now we'll use this to force a spawn point
		blocks[8,8,0].spawn = true;

		comp = true;
	} */
	#endregion

	#region new_version

	public void Start() {

		Vector3 currpos = Vector3.zero;

		blocks = new Block[50,50,50];

		string text = map_file.text;
		char[] delim = {'{','}'};

		string[] layers = text.Split (delim, System.StringSplitOptions.RemoveEmptyEntries);

		//this is a layer
		foreach (string s in layers) {
			//Cleaning up leftover junk
			if (s.Contains("(")) {
				string[] rows = s.Split (new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);

				//this is a row
				foreach (string s2 in rows) {
					string[] entries = s2.Split(new char[] {'(',')'}, System.StringSplitOptions.RemoveEmptyEntries);
					//this is a block
					foreach (string s3 in entries) {
						if (s3 != "0") {
							GameObject g = (GameObject) Instantiate(block_prefab, currpos, Quaternion.identity);
							if (texture_names.Contains(s3)) {
								g.GetComponent<Block>().UpdateTexture(textures[texture_names.IndexOf(s3)]);
							}
							blocks [(int)currpos.x, (int)currpos.z, (int)currpos.y] = g.GetComponent<Block>();
						}
						currpos += Vector3.right;
					}
					currpos = new Vector3 (0, currpos.y, currpos.z);
					currpos += Vector3.forward;
				}
				currpos = new Vector3 (0, currpos.y + 1, 0);
			}
		}

		for (int i=1; i<50; i++) {
			for (int j=1; j<50; j++) {
				for (int k=0; k<50; k++) {
					if (blocks[i,j,k] != null) {
						blocks[i,j,k].SetPos (new Vector3 (i,j,k));
						blocks[i,j,k].SetMap (blocks);
					}
				}
			}
		}

		comp = true;
		blocks [0, 0, 0].spawn = true;
	}

	#endregion

	public Block[,,] GetBlocks() {
		return blocks;
	}
}
