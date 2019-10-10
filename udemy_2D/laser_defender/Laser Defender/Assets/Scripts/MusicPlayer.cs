using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
	public static MusicPlayer Instance
	{ get; private set; }

	private void Awake()
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

	//private void Awake()
	//{
	//	SetUpSingleton();
	//}

	//private void SetUpSingleton()
	//{
	//	if (FindObjectsOfType(GetType()).Length > 1)
	//	{
	//		Destroy(gameObject);
	//	}
	//	else
	//	{
	//		DontDestroyOnLoad(gameObject);
	//	}
	//}
}
