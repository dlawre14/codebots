using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Parser {

	[Tooltip ("File for debugging parser...")]
	public TextAsset file;

	private List<string> output = new List<string>();
	private char[] delims = {'\n', ' ', '\t'};

	public List<string> Parse(string input) {
		string[] temp = input.Split(delims);
		List<string> tokens = new List<string>();
		foreach (string s in temp) {
			if (s != "")
				tokens.Add (s);
		}

		int i = 0;
		while (i < tokens.Count) {
			if (tokens[i] == "Loop") {
				List<string> subtokens = new List<string>();
				int loop_times = System.Convert.ToInt32 (tokens[i+1]);
				if (tokens[i+2] == "{") {
					i+=3;
					int close_bracket_count = 1;
					while (close_bracket_count > 0) {
						if (tokens[i] == "}")
							close_bracket_count--;
						if (tokens[i] == "{")
							close_bracket_count++;
						if (close_bracket_count > 0) {
							subtokens.Add (tokens[i]);
							i++;
						}
						if (i > tokens.Count) {
							output.Clear ();
                            return output;
                        }
                    }
					Looper(loop_times, subtokens);
				}
				else {
					Debug.LogError ("Syntax Error! Missing '{' after Loop declaration.");
				}
			}
			else if (tokens[i] == "Forward") {
				output.Add ("FWD");
			}
			else if (tokens[i] == "Backward") {
				output.Add ("BWD");
			}
			else if (tokens[i] == "Left") {
				output.Add ("LFT");
			}
			else if (tokens[i] == "Right") {
				output.Add ("RGT");
			}
			else {
				Debug.LogError("Command " + tokens[i] + " is unknown");
			}
			i++;
		}

		return output;
	}

	private void Looper(int count, List<string> tokens) {
		for (int j=0; j<count; j++) {
			int i = 0;
			while (i < tokens.Count) {
				if (tokens[i] == "Loop") {
					List<string> subtokens = new List<string>();
					int loop_times = System.Convert.ToInt32 (tokens[i+1]);
					if (tokens[i+2] == "{") {
						i+=3;
						int close_bracket_count = 1;
						while (close_bracket_count > 0) {
							if (tokens[i] == "}")
								close_bracket_count--;
							if (tokens[i] == "{")
								close_bracket_count++;
							if (close_bracket_count > 0) {
								subtokens.Add (tokens[i]);
								i++;
							}
							if (i > tokens.Count) {
								output.Clear ();
								return;
							}
						}
						Looper(loop_times, subtokens);
					}
					else {
                        Debug.LogError ("Syntax Error! Missing '{' after Loop declaration.");
                    }
                }
				else if (tokens[i] == "Forward") {
					output.Add ("FWD");
				}
				else if (tokens[i] == "Backward") {
					output.Add ("BWD");
				}
				else if (tokens[i] == "Left") {
					output.Add ("LFT");
                }
                else if (tokens[i] == "Right") {
                    output.Add ("RGT");
                }
                else {
                    Debug.LogError("Command " + tokens[i] + " is unknown");
				}
				i++;
			}
		}
	}

	//For debugging...
	void Start() {
		//Parse (file.text);
	}
}
