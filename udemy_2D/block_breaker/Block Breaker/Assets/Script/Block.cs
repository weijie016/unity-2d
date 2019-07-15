using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	// configuration parameters
	[SerializeField] AudioClip breakSound;
	[SerializeField] GameObject blockSparklesVFX;
	[SerializeField] Sprite[] hitSprites;

	// cached referenced
	Level level;

	// state
	[SerializeField] int timesHit;  // TODO: only serialized for debug

	private void Start()
	{
		CountBreakableBlocks();
	}

	private void CountBreakableBlocks()
	{
		level = FindObjectOfType<Level>();
		if (tag == "Breakable")
		{
			level.CountBlocks();
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (tag == "Breakable")
		{
			HandleHit();
		}
	}

	private void HandleHit()
	{
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits)
		{
			DestroyBlock();
		}
		else
		{
			ShowNextHitSprite();
		}
	}

	private void ShowNextHitSprite()
	{
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex] != null)
		{
			GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
		else
		{
			Debug.LogError("Block sprite is missing from array: " + gameObject.name);
		}
		
	}

	private void DestroyBlock()
	{
		// Play destroy SFX
		AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, 0.07f);

		// VFX
		TriggerSparklesVFX();

		// Destroy and add score
		level.BlockDestroyed();
		FindObjectOfType<GameSession>().AddToScore();
		Destroy(gameObject);
	}

	private void TriggerSparklesVFX()
	{
		GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
		Destroy(sparkles, 1.2f);
	}
}
