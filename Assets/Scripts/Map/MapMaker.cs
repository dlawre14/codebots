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
		}
	}

	private static char[] delims = {'(', ')', ' '};
	private Block[,,] blocks;
	
	// Use this for initialization
	void Start () {
		string text = map_file.text;
		string[] lines = text.Split('\n');
		int width = lines.Length;
		int length = lines[0].Split (' ').Length;
		
		blocks = new Block[width+1,length+1,25]; //assume no stack is taller than 25
		Vector3 pos = Vector3.zero;
		
		foreach (string line in lines) {
			string[] vals = line.Split (delims);
			foreach (string val in vals) {
				if (val != "") {
					for (int i = 0; i < System.Convert.ToInt32(val); i++) {
						GameObject g = (GameObject) Instantiate(block_prefab, pos, Quaternion.identity);
						g.transform.parent = transform;
						blocks[(int)pos.x, (int)pos.z, (int)pos.y] = g.GetComponent<Block>();
						pos.y += 1;
					}
					pos.y = 0;
					pos.z += 1;
				}
			}
			pos.z = 0;
			pos.x += 1;
		}
		
		//for now we'll use this to force a spawn point
		blocks[8,8,0].spawn = true;
		
		comp = true;
	}
	
	public Block[,,] GetBlocks() {
		return blocks;
	}
}
