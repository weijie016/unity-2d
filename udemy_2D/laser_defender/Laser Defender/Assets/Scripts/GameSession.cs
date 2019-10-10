using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
	public static GameSession Instance
	{ get; private set; }
	int totalScore = 0;

	private void Awake()
	{
		SetupSingleton();
	}

	private void SetupSingleton()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			gameObject.SetActive(false);
			Destroy(gameObject);
		}
	}

	public int GetScore()
	{
		return totalScore;
	}

	public void AddToScore(int score)
	{
		totalScore += score;
	}

	public void ResetGame()
	{
		Destroy(gameObject);
	}
}
