using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[Header("Enemy")]
	[SerializeField] float health = 100;
	[SerializeField] int score = 100;

	[Header("Projectile")]
	[SerializeField] float minTimeBetweenShots = 0.2f;
	[SerializeField] float maxTimeBetweenShots = 2.5f;
	[SerializeField] GameObject laserPrefab;
	[SerializeField] float projectileSpeed = 10f;
	[SerializeField] AudioClip shootingSFX;
	[SerializeField] [Range(0, 1)] float shootingVol = 0.5f;
	float shotCounter;

	[Header("Death")]
	[SerializeField] GameObject deathVFX;
	[SerializeField] float explosionDuration = 1f;
	[SerializeField] AudioClip deathSFX;
	[SerializeField] [Range(0, 1)] float deathVol = 0.5f;

	ScoreDisplay scoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
		shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
		scoreDisplay = FindObjectOfType<ScoreDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
		CountdownAndShoot();
    }

	private void CountdownAndShoot()
	{
		shotCounter -= Time.deltaTime;
		if (shotCounter <= 0f)
		{
			Fire();
			shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
		}
	}

	private void Fire()
	{
		GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.Euler(0f, 0f, 180f));
		laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
		AudioSource.PlayClipAtPoint(shootingSFX, Camera.main.transform.position, shootingVol);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
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
	}

	private void Die()
	{
		// die animation and vfx, sfx
		Destroy(gameObject);
		GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
		Destroy(explosion, explosionDuration);
		AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathVol);

		// score system
		FindObjectOfType<GameSession>().AddToScore(score);

		// update score text
		scoreDisplay.UpdateScoreText();
	}
}
