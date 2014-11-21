using UnityEngine;
using System.Collections;

public class LightBurstParticle : MonoBehaviour {

    public GameObject particle;
    public int num_particles;
    public float xz_plane_strength;
    public float y_strength;

    public bool upward_only;

    [Range (0.1f, 1000000.0f)]
    [Tooltip ("If upward only, specifies the minimum amount of upward force")]
    public float min_upward;

	// Use this for initialization
    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("Custom Particle").Length < 2500)
        {
            for (int i = 0; i < num_particles; i++)
            {
                GameObject g = (GameObject)Instantiate(particle, transform.position, Quaternion.identity);
                if (!upward_only)
                    g.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-xz_plane_strength, xz_plane_strength), Random.Range(-y_strength, y_strength), Random.Range(-xz_plane_strength, xz_plane_strength));
                else
                    g.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-xz_plane_strength, xz_plane_strength), Random.Range(min_upward, y_strength), Random.Range(-xz_plane_strength, xz_plane_strength));
            }
        }
    }
}
