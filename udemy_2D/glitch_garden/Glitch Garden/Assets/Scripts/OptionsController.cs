using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
	[SerializeField] Slider volumeSlider;
	[SerializeField] float defaultVolume = 0.5f;
	[SerializeField] Slider difficultySlider;
	[SerializeField] float defaultDifficulty = 0.5f;

	MusicPlayer musicPlayer;

    // Start is called before the first frame update
    void Start()
    {
		volumeSlider.value = PlayerPrefsController.GetMasterVolume();
		musicPlayer = FindObjectOfType<MusicPlayer>();
		difficultySlider.value = PlayerPrefsController.GetDifficulty();
	}

    public void UpdateVolume()
    {
		if (musicPlayer)
		{
			musicPlayer.SetVolume(volumeSlider.value);
		}
		else
		{
			Debug.LogError("No music player found in options screen");
		}
    }

	public void SaveAndExit()
	{
		PlayerPrefsController.SetMasterVolume(volumeSlider.value);
		PlayerPrefsController.SetDifficulty(difficultySlider.value);
		FindObjectOfType<LevelLoader>().LoadMainMenuScene();
	}

	public void SetDefault()
	{
		volumeSlider.value = defaultVolume;
		difficultySlider.value = defaultDifficulty;
	}
}
