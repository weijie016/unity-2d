using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
	[Range(0.1f, 10f)] [SerializeField] float gameSpeed = 0.9f;

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey(KeyCode.Space))
		{
			gameSpeed = 0.4f;
		}
		else
		{
			gameSpeed = 0.9f;
		}

		Time.timeScale = gameSpeed;
		if (gameSpeed < 1f)
		{
			Time.fixedDeltaTime = 0.02f * gameSpeed;
		}
		else
		{
			Time.fixedDeltaTime = 0.02f;
		}
	}
}
