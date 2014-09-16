using UnityEngine;
using System.Collections;

public class TestGUI : MonoBehaviour {

	public static void OutlineLabel(Rect position, string text, GUIStyle style, string textColor = "#FFFFFF", string outlineColor = "#000000") {
		float w = position.position.x;
		float h = position.position.y;

		position.position = new Vector2 (w + 1, h + 1);
		GUI.Label (position, "<color=" + outlineColor + ">" + text + "</color>", style);
		position.position = new Vector2 (w + 1, h - 1);
		GUI.Label (position, "<color=" + outlineColor + ">" + text + "</color>", style);
		position.position = new Vector2 (w - 1, h + 1);
		GUI.Label (position, "<color=" + outlineColor + ">" + text + "</color>", style);
		position.position = new Vector2 (w - 1, h - 1);
		GUI.Label (position, "<color=" + outlineColor + ">" + text + "</color>", style);
		position.position = new Vector2 (w, h); 
		GUI.Label (position, "<color=" + textColor + ">" + text + "</color>", style);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GUIStyle style = new GUIStyle();
		style.fontSize = 20;
		style.richText = true;
		style.alignment = TextAnchor.MiddleCenter;

		OutlineLabel (new Rect(Screen.width/2.0f - 100/2.0f,0,100,20), "Codebots -- Debug Client", style);
	}
}
