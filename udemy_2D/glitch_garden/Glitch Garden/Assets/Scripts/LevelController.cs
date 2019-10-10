using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
	[SerializeField] GameObject winLabel;
	[SerializeField] GameObject loseLabel;
	[SerializeField] float winWaitTime = 3f;

	int numberOfAttacker = 0;
	bool levelTimerFinished = false;

	private void Start()
	{
		winLabel.SetActive(false);
		loseLabel.SetActive(false);
	}

	public void AttackerSpawned()
	{
		numberOfAttacker++;
	}

	public void AttackerKilled()
	{
		numberOfAttacker--;
		if (numberOfAttacker <= 0 && levelTimerFinished)
		{
			StartCoroutine(HandleWinCondition());
		}
	}

	private IEnumerator HandleWinCondition()
	{
		GetComponent<AudioSource>().Play();
		winLabel.SetActive(true);
		yield return new WaitForSeconds(winWaitTime);
		FindObjectOfType<LevelLoader>().LoadNextScene();
	}

	public void HandleLoseCondition()
	{
		loseLabel.SetActive(true);
		Time.timeScale = 0;
	}

	public void LevelTimerFinished()
	{
		levelTimerFinished = true;
		StopSpawners();
	}

	private void StopSpawners()
	{
		AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
		foreach (AttackerSpawner attackerSpawner in spawnerArray)
		{
			attackerSpawner.StopSpawner();
		}
	}
}
