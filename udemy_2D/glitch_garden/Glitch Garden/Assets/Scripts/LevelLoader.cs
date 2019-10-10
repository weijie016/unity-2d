using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader: MonoBehaviour
{
	[SerializeField] int waitTime = 5;

	int currSceneIndex;

	void Start()
	{
		currSceneIndex = SceneManager.GetActiveScene().buildIndex;
		if (currSceneIndex == 0)
		{
			StartCoroutine(WaitForTime());
		}
	}

	IEnumerator WaitForTime()
	{
		yield return new WaitForSeconds(waitTime);
		LoadNextScene();
	}

	public void RestartScene()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(currSceneIndex);
	}

	public void LoadMainMenuScene()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("Start Screen");
	}

	public void LoadOptionsScene()
	{
		SceneManager.LoadScene("Options Screen");
	}

	public void LoadNextScene()
	{
		SceneManager.LoadScene(currSceneIndex + 1);
	}

	public void LoadLoseScreen()
	{
		SceneManager.LoadScene("Lose Screen");
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
