﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	[SerializeField] int health = 200;
	[SerializeField] GameObject deathVFX;

	public void DealDamage(int damage)
	{
		health -= damage;
		if (health <= 0)
		{
			TriggerDeathVFX();
			Destroy(gameObject);
		}
	}

	private void TriggerDeathVFX()
	{
		if (!deathVFX)
		{
			return;
		}
		GameObject deathVFXObject = Instantiate(deathVFX, transform.position, Quaternion.identity);
		Destroy(deathVFXObject, 1f);
	}
}
