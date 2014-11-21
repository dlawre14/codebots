using UnityEngine;
using System.Collections;

public class TestLauncher : MonoBehaviour {

    public Vector3 position;
    public float force;
    public GameObject projectile;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject g = (GameObject) Instantiate(projectile, position, Quaternion.identity);
            g.GetComponent<Projectile2>().force = force;
        }
	}
}
