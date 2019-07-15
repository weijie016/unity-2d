using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
	[SerializeField] Text textComponent;
	[SerializeField] State startingState;

	State state;
	private KeyCode[] combo = { KeyCode.Alpha8, KeyCode.Alpha5, KeyCode.Alpha7, KeyCode.Alpha5 };
	private int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
		state = startingState;
		textComponent.text = state.GetStateStory();
    }

    // Update is called once per frame
    void Update()
    {
		ManageState();
    }

	private void ManageState()
	{
		var nextStates = state.GetNextStates();
		//for (int i = 0; i < nextStates.Length; i++)
		//{
		//	if (Input.GetKeyDown(KeyCode.Alpha1 + i))
		//	{
		//		state = nextStates[i];
		//	}
		//}

		for (int i = 0; i < 2; i++)
		{
			if (Input.GetKeyDown(KeyCode.Alpha1 + i))
			{
				state = nextStates[i];
			}
		}

		if (Input.GetKeyDown(combo[currentIndex]))
		{
			currentIndex++;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			// does not exist but for the lesson
			state = nextStates[3];
		}


		if (currentIndex == 4)
		{
			currentIndex = 0;
			state = nextStates[2];
		}
		textComponent.text = state.GetStateStory();
	}
}
