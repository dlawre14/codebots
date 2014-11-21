using UnityEngine;
using System.Collections;

public class Projectile2 : MonoBehaviour {

    public float force;
    public GameObject particle;

	// Use this for initialization
	void Start () {
        rigidbody.AddForce(Vector3.forward * force);
	}

    void OnCollisionEnter(Collision c)
    {
        Instantiate(particle, c.contacts[0].point, Quaternion.identity);
        Destroy(gameObject);
    }
}
