using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class FlashingLight : MonoBehaviour
{
	private Light2D _light2D;
    private void Awake()
    {
        _light2D = GetComponent<Light2D>();
    }

    void Update()
	{

        float nosie = Mathf.PerlinNoise(Time.time, Time.time * 5.0f);
        _light2D.intensity = Mathf.Lerp(0f,1.5f,nosie);
	}
}
