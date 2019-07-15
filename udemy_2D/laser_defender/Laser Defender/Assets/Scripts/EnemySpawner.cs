﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] List<WaveConfig> waveConfigs;

	int startingWave = 0;

    // Start is called before the first frame update
    void Start()
    {
		var currWave = waveConfigs[startingWave];
		StartCoroutine(SpawnAllEnemiesInWave(currWave));
    }

	private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
	{
		for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
		{
			Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWaypoints()[0].position, Quaternion.identity);
			yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
		}
	}
}
