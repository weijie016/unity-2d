﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{

	// configuration parameters
	[SerializeField] int scorePerBlock = 20;
	[SerializeField] TextMeshProUGUI scoreText;
	[SerializeField] bool isAutoPlayEnabled;

	// state
	[SerializeField] int currentScore = 0;

	private void Awake()
	{
		int gameStatusCount = FindObjectsOfType<GameSession>().Length;
		if (gameStatusCount > 1)
		{
			gameObject.SetActive(false);
			Destroy(gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
		}
	}

	private void Start()
	{
		scoreText.text = currentScore.ToString();
	}

	public void AddToScore()
	{
		currentScore += scorePerBlock;
		scoreText.text = currentScore.ToString();
	}

	public void ResetGame()
	{
		Destroy(gameObject);
	}

	public bool IsAutoPlayEnabled()
	{
		return isAutoPlayEnabled;
	}
}
