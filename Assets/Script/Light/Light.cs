using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class Light : MonoBehaviour
{
	private Light2D _light2D;
	private float timer = 0;

    private void Awake()
    {
		_light2D = GetComponent<Light2D>();
	}

    void Update()
	{
		LightTimer();

		_light2D.intensity = Mathf.Lerp(0, 1, timer);
		//这里我们用线性插值和timer实现渐变
		//如果要控制在指定时间内变换，在Time.deltatime上乘“1/指定时间”即可
	}

	private void LightTimer()
	{
		if (Input.GetKey(KeyCode.Q) && timer <= 1)//按住L渐亮
		{
			timer += Time.deltaTime;
		}
		else if (timer >= 0)//松开L渐暗
		{
			timer -= Time.deltaTime;
		}
	}
}



