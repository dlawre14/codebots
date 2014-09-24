using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapEditor : MonoBehaviour {
	
	public GameObject map_obj;
	
	public GameObject panel;
	
	public InputField length;
	public InputField width;
	
	private Vector2 dimensions;
	
	private string[] map;

	// Use this for initialization
	void Start () {
		CreateFields();
	}
	
	// Update is called once per frame
	void Update () {
		try {
			GetComponent<RectTransform> ().sizeDelta = new Vector2 (System.Convert.ToInt32(width.value) * 100,System.Convert.ToInt32(length.value) * 30);
			dimensions = new Vector2 (System.Convert.ToInt32(width.value),System.Convert.ToInt32(length.value));
			}
		catch (System.FormatException) {	}				
	}

	public void CreateFields() {
		foreach (Transform child in transform) {
			Destroy (child.gameObject);
		}
		for (int i = 0; i < System.Convert.ToInt32(length.value); i++) {
			for (int j = 0; j < System.Convert.ToInt32(width.value); j++) {
					GameObject g = (GameObject)Instantiate (panel);
					g.transform.parent = transform;
					g.GetComponent<InputBox>().SetPosition(i,j);
			}
		}
	}
	
	public void WriteMapFile() {
		int[,] heights = new int[(int)dimensions.x, (int)dimensions.y];
		foreach (Transform child in transform) {
			Vector2 pos = child.GetComponent<InputBox>().GetPosition();
			heights[(int) pos.x, (int) pos.y] = child.GetComponent<InputBox>().GetValue();
		}
		map = new string[(int)dimensions.x];
		for (int i = 0; i < dimensions.x; i++) {
			for (int j = 0; j < dimensions.y; j++) {
				map[i] += ("(" + heights[i,j] + ",0) ");
			}
		}
		GenerateMap(); //for now
	}
	
	public void GenerateMap() {
		map_obj.GetComponent<MapMaker>().BuildMap(map);
	}
	
	public string[] GetMap() {
		return map;
	}
}
