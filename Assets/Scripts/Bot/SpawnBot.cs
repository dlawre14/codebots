using UnityEngine;
using System.Collections;

public class SpawnBot : MonoBehaviour {
	
	public GameObject map;
	public GameObject bot;
	
	private bool spawned = false;
	
	// Update is called once per frame
	void Update () {
		if (!spawned && map.GetComponent<MapMaker>().complete) {
			foreach (Block b in map.GetComponent<MapMaker>().GetBlocks()) {
				if (b && b.spawn) {
					Instantiate(bot, b.transform.position + Vector3.up, Quaternion.identity);
				}
			}
			spawned = true;
		}
	}
}
