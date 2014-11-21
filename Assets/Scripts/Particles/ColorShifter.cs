using UnityEngine;
using System.Collections;

public class ColorShifter : MonoBehaviour {

    public float lifetime;
    public Color start_color;
    public Color end_color;
    public bool fade_when_finished;
    public float fade_delay;
    public bool destroy_when_finished;
    public float destroy_delay;

    private Light light;

	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();
        light.color = start_color;
        StartCoroutine(ColorShift());
	}

    IEnumerator ColorShift()
    {
        float rtomove = ((end_color.r - start_color.r) / lifetime) * 0.1f;
        float gtomove = ((end_color.g - start_color.g) / lifetime) * 0.1f;
        float btomove = ((end_color.b - start_color.b) / lifetime) * 0.1f;
        for (float i = 0.0f; i < lifetime; i += 0.1f)
        {
            light.color = new Color(light.color.r + rtomove, light.color.g + gtomove, light.color.b + btomove);
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(fade_delay);

        if (fade_when_finished)
        {
            for (float i = 0.0f; light.intensity > 0; i += 0.1f) {
                light.intensity -= 0.1f;
                yield return new WaitForSeconds(0.1f);
            }
        }

        yield return new WaitForSeconds(destroy_delay);

        if (destroy_when_finished)
            Destroy(transform.parent.gameObject);
    }

}
