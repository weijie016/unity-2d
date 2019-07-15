using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
	// config params
	[SerializeField] WaveConfig waveConfig;
	[SerializeField] float moveSpeed = 3f;

	// state
	List<Transform> waypoints;
	int waypointIndex = 0;

	// Start is called before the first frame update
	void Start()
    {
		waypoints = waveConfig.GetWaypoints();
		transform.position = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    void Update()
	{
		Move();
	}

	private void Move()
	{
		if (waypointIndex <= waypoints.Count - 1)
		{
			var targetPos = waypoints[waypointIndex].position;
			var movementThisFrame = moveSpeed * Time.deltaTime;
			transform.position = Vector2.MoveTowards(transform.position, targetPos, movementThisFrame);
			if (transform.position == targetPos)
			{
				waypointIndex++;
			}
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
