﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravestone : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Attacker attacker = collision.GetComponent<Attacker>();
		
		if (attacker)
		{
			// TODO: add animation
		}
	}
}
