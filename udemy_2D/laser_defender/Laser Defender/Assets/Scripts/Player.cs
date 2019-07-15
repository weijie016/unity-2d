using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	// configuration parameters
	[SerializeField] float moveSpeed = 10f;
	[SerializeField] float padding = 0.7f;
	[SerializeField] GameObject laserPrefab;
	[SerializeField] float projectileSpeed = 25f;
	[SerializeField] float projectileFiringPeriod = 0.1f;

	Coroutine firingCoroutine;

	// state
	float xMin;
	float xMax;
	float yMin;
	float yMax;
	bool isFiring = false;

    // Start is called before the first frame update
    void Start()
    {
		SetUpMoveBoundaries();
		StartCoroutine(FireContinuously());
	}

	// Update is called once per frame
	void Update()
    {
		Move();
		//Fire();
	}

	private void Move()
	{
		var deltaX = Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;
		var deltaY = Input.GetAxisRaw("Vertical") * Time.deltaTime * moveSpeed;

		var nextXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
		var nextYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

		transform.position = new Vector2(nextXPos, nextYPos);
	}

	//private void Fire()
	//{
	//	if (Input.GetButtonDown("Fire1"))
	//	{
	//		firingCoroutine = StartCoroutine(FireContinuously());
	//	}
	//	if (Input.GetButtonUp("Fire1"))
	//	{
	//		StopCoroutine(firingCoroutine);
	//	}
	//}

	//IEnumerator FireContinuously()
	//{
	//	while(true)
	//	{
	//		GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
	//		laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
	//		yield return new WaitForSeconds(projectileFiringPeriod);
	//	}
	//}

	IEnumerator FireContinuously()
	{
		while (true)
		{
			if (Input.GetButton("Fire1"))
			{
				GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
				laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
				yield return new WaitForSeconds(projectileFiringPeriod);
			}
			yield return null;
		}
	}

	private void SetUpMoveBoundaries()
	{
		Camera gameCamera = Camera.main;
		xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
		xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
		yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
		yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
	}
}
