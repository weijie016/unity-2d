using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthDisplay : MonoBehaviour
{
	Text healthText;
	Player player;
	int maxHealth;
	int prevHealth;

    // Start is called before the first frame update
    void Start()
    {
		// get health text component and set to green
		healthText = GetComponent<Text>();
		healthText.color = new Color(0, 255, 0);

		player = FindObjectOfType<Player>();
		maxHealth = player.GetHealth();
		prevHealth = maxHealth;
    }

	public void UpdateHealthText()
	{
		int currHealth = player.GetHealth();
		float currHealthPercent = currHealth * 100f / maxHealth;
		if (currHealth != prevHealth) {
			if (currHealthPercent < 20)
			{
				healthText.color = new Color(255, 0, 0);
			}
			else if (currHealthPercent <= 50)
			{
				healthText.color = new Color(255, 128, 0);
			}
			prevHealth = currHealth;
		}
		healthText.text = currHealth.ToString();
	}
}
