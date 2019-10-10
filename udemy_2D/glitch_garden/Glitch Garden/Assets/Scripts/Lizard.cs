using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		GameObject otherObject = collision.gameObject;

		Defender defender = otherObject.GetComponent<Defender>();
		if (defender)
		{
			GetComponent<Attacker>().Attack(otherObject);
		}
	}
}
