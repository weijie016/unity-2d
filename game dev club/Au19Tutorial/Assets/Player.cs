using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Rigidbody2D myRigidbody2D;

    // Update is called once per frame
    void Update()
    {
		float horizVelocity = Input.GetAxis("Horizontal") * 5;
		float vertVelocity = myRigidbody2D.velocity.y;

		if (Input.GetKeyDown(KeyCode.Space))
		{
			vertVelocity += 10;
		}

		myRigidbody2D.velocity = new Vector2(horizVelocity, vertVelocity);
    }
}
