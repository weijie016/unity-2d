using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
	[SerializeField] [Range(0, 3)] float delayInSeconds = 0.6f;

	public void LoadStartMenu()
	{
		SceneManager.LoadScene(0);
	}

	public void LoadGameScene()
	{
		SceneManager.LoadScene("Game");
		var gameSession = FindObjectOfType<GameSession>();
		if (gameSession)
		{
			FindObjectOfType<GameSession>().ResetGame();
		}
	}

	public void LoadGameOver()
	{
		StartCoroutine(WaitAndLoadGameOver());
	}

	IEnumerator WaitAndLoadGameOver()
	{
		yield return new WaitForSeconds(0.5f);
		SceneManager.LoadScene("Game Over");
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
