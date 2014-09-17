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

	private float xpos = -100;
	private bool popup = false;
	private bool rendered = true;

	private string angle;

	private Rect windowrect = new Rect(Screen.width/2.0f - 125, Screen.height/2.0f - 50,250,100);

	void OnGUI() {
		GUIStyle style = new GUIStyle();
		style.fontSize = 20;
		style.richText = true;
		style.alignment = TextAnchor.MiddleCenter;

		OutlineLabel (new Rect(Screen.width/2.0f - 100/2.0f,0,100,20), "Codebots -- Debug Client", style);

		/** Left Side Panel */
		GUILayout.BeginArea(new Rect(xpos, Screen.height/2.0f - 150, 100, 300));

		if (GUILayout.Button ("Forward")) {
			//Do Stuff
		}
		if (GUILayout.Button ("Left Turn")) {
			popup = true;
		}
		if (GUILayout.Button ("Right Turn")) {
			//Do Stuff
		}
		if (GUILayout.Button ("Reverse")) {
			//Do Stuff
		}

		GUILayout.EndArea();

		/** Left Side Panel Toggl */
		GUILayout.BeginArea (new Rect(xpos + 100, Screen.height/2.0f - 25, 30, 50));

		if (xpos < 0) {
			if (GUILayout.Button (">>"))
				xpos += 100;
		}
		else {
			if (GUILayout.Button ("<<"))
				xpos -= 100;
		}

		GUILayout.EndArea();

		//popup window
		if (popup) {
			windowrect = GUI.ModalWindow (0, windowrect, PromptWindow, "Customize Maneuver");
		}
	}



	//Pop-up Window Fumctions
	void PromptWindow(int windowid) {
		GUILayout.BeginArea(new Rect(10,20,200,200));

		GUILayout.Label("Enter degrees to move...");
		angle = GUILayout.TextField(angle);

			GUILayout.BeginHorizontal();
			GUILayout.Button ("Confirm");
			GUILayout.Button ("Cancel");

			GUILayout.EndHorizontal();

		GUILayout.EndArea();
	}
}
