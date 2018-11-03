using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Call the function WaterReact() to animate the water ripples.
public class water_tub_script : MonoBehaviour {

    private Material water_tub;
    private float ripple_multiplier = 1f;  // range is between 0 and 2
    public float ripple_duration = 1.5f;  // number of seconds
    private float ripple_lerp = 0f;
    private float start_time = 0f;
    private float current_time = 0f;

    void Start()
    {
        water_tub = GetComponent<Renderer>().material;
    }

    void WaterReact()
    {
        start_time = Time.deltaTime;
        ripple_lerp = 0f;
        StartCoroutine("WaterLerp");
    }

    IEnumerator WaterLerp()
    {
        while (ripple_lerp < 1f)
        {
            current_time = Time.deltaTime;
            // normalize the duration
            ripple_lerp = (current_time - start_time) / ripple_duration;
            // the ripple multiplier starts at 2 (big waves) then drops to 1 (small waves) over the number of seconds defined by ripple_duration
            ripple_multiplier = Mathf.Lerp(2f, 1f, ripple_lerp);
            water_tub.SetFloat("_ripple_multiplier", ripple_multiplier);
            yield return null;
        }
    }
}
