using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
	Text scoreText;
	GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
		scoreText = GetComponent<Text>();
		gameSession = FindObjectOfType<GameSession>();
		scoreText.text = gameSession.GetScore().ToString();
	}

	// Update is called once per frame
	public void UpdateScoreText()
    {
		scoreText.text = gameSession.GetScore().ToString();
	}
}
