using UnityEngine;
using System.Collections;

public class Bot : MonoBehaviour {

    private int health;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (health == 0)
            DestroyBot();
	}

    public void botHit()
    {
        health--;
    }

    private void DestroyBot()
    {
        //Setup destruction objects, particles, etc.

        //Call coroutines for timing events
    }
}
