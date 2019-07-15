using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

	// state
	[SerializeField] int breakableBlockCount;  // Serialized for debugging purposes

	// cached reference
	SceneLoader sceneLoader;

	public void Start()
	{
		sceneLoader = FindObjectOfType<SceneLoader>();
	}

	public void CountBlocks()
	{
		breakableBlockCount++;
	}

	public void BlockDestroyed()
	{
		breakableBlockCount--;
		if (breakableBlockCount <= 0)
		{
			sceneLoader.LoadNextScene();
		}
	}
}
