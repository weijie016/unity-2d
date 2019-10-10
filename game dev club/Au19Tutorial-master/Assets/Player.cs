using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody2D;
    public BoxCollider2D myGroundCollider;

    public float moveSpeed = 5;
    public float jumpHeight = 10;

    private float time = 2;

    // Update is called once per frame
    void Update()
    {
        float horizVelocity = Input.GetAxis("Horizontal") * moveSpeed;
        float vertVelocity = myRigidbody2D.velocity.y;

        if (Input.GetKeyDown(KeyCode.Space) && myGroundCollider.IsTouchingLayers()) {
            vertVelocity += jumpHeight;
        }

        myRigidbody2D.velocity = new Vector2(horizVelocity, vertVelocity);

        if (time > 1) {
            time = 0;
            float hue = Random.Range(0f, 1f);
            Color c = Color.HSVToRGB(hue, 1, 1);
            GetComponent<SpriteRenderer>().color = c;
            GetComponent<TrailRenderer>().startColor = c;
            GetComponent<TrailRenderer>().endColor = Color.HSVToRGB((hue + 0.5f) % 1, 1, 1);
        } else {
            time += Time.deltaTime;
        }
    }
}
