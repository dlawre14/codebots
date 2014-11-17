using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float force;

	// Use this for initialization
	void Start () {
		rigidbody.AddForce (new Vector3 (0, 0, force));
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter() {
		rigidbody.isKinematic = true;
		GetComponent<MeshRenderer> ().enabled = false;

		ParticleSystem s = GetComponent<ParticleSystem> ();
		s.Play ();

		StartCoroutine(StartDestroy ());
	}

	IEnumerator StartDestroy() {
		yield return new WaitForSeconds(1.5f);
		Destroy (gameObject);
	}
}
