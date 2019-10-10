using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField] float speed = 1f;
	[SerializeField] int damage = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.Translate(Vector2.right * Time.deltaTime * speed);
    }

	private void OnTriggerEnter2D(Collider2D otherCollider)
	{
		var attacker = otherCollider.GetComponent<Attacker>();
		var health = otherCollider.GetComponent<Health>();
		if (attacker && health)
		{
			health.DealDamage(damage);
			Destroy(gameObject);
		}
	}
}
