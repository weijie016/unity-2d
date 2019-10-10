using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthDisplay : MonoBehaviour
{
	[SerializeField] int baseLives = 10;
	int health;
	Text healthText;

    void Start()
    {
		health = baseLives - Mathf.FloorToInt(PlayerPrefsController.GetDifficulty() * (baseLives - 1));
		Debug.Log("difficulty setting currently is " + PlayerPrefsController.GetDifficulty());
		healthText = GetComponent<Text>();
		UpdateDisplay();
    }

	public void DecreaseHealth()
	{
		health--;
		CheckLose();
		UpdateDisplay();
	}

	private void CheckLose()
	{
		if (health <= 0)
		{
			FindObjectOfType<LevelController>().HandleLoseCondition();
		}
	}

	void UpdateDisplay()
    {
		healthText.text = health.ToString();
    }
}
