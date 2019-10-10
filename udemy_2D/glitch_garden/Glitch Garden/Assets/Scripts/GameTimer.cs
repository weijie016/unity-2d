using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
	[Tooltip("Our level timer in seconds")]
	[SerializeField] float levelTime = 10f;

	Slider slider;
	bool triggeredLevelTimer = false;

	private void Start()
	{
		slider = GetComponent<Slider>();
	}

	void Update()
    {
		if (triggeredLevelTimer)
		{
			return;
		}

		slider.value = Time.timeSinceLevelLoad / levelTime;

		bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
		if (timerFinished)
		{
			FindObjectOfType<LevelController>().LevelTimerFinished();
			triggeredLevelTimer = true;
		}
    }
}
