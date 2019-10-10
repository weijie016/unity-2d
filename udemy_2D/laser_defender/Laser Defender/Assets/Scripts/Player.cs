using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	// configuration parameters
	[Header("Player Movement")]
	[SerializeField] float moveSpeed = 10f;
	[SerializeField] float padding = 0.7f;
	[SerializeField] int health = 1000;

	[Header("Projectile")]
	[SerializeField] GameObject laserPrefab;
	[SerializeField] float projectileSpeed = 25f;
	[SerializeField] float projectileFiringPeriod = 0.1f;
	[SerializeField] AudioClip shootingSFX;
	[SerializeField] [Range(0, 1)] float shootingVol = 0.5f;

	[Header("Death")]
	[SerializeField] AudioClip deathSFX;
	[SerializeField] [Range(0, 1)] float deathVol = 0.5f;

	Coroutine firingCoroutine;
	HealthDisplay healthDisplay;

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
		healthDisplay = FindObjectOfType<HealthDisplay>();
	}

	// Update is called once per frame
	void Update()
    {
		Move();
		//Fire();
	}

	public int GetHealth()
	{
		return Mathf.Max(health, 0);
	}

	private void Move()
	{
		var deltaX = Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;
		var deltaY = Input.GetAxisRaw("Vertical") * Time.deltaTime * moveSpeed;

		var nextXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
		var nextYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

		transform.position = new Vector2(nextXPos, nextYPos);
	}

	IEnumerator FireContinuously()
	{
		while (true)
		{
			if (Input.GetButton("Fire1"))
			{
				GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
				laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
				AudioSource.PlayClipAtPoint(shootingSFX, Camera.main.transform.position, shootingVol);
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

	private void OnTriggerEnter2D(Collider2D collision)
	{
		DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
		if (!damageDealer)
		{
			return;
		}
		ProcessHit(damageDealer);
	}

	private void ProcessHit(DamageDealer damageDealer)
	{
		health -= damageDealer.GetDamage();
		damageDealer.Hit();
		if (health <= 0)
		{
			Die();
		}
		healthDisplay.UpdateHealthText();
	}

	private void Die()
	{
		FindObjectOfType<Level>().LoadGameOver();
		Destroy(gameObject);
		AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathVol);
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
}
