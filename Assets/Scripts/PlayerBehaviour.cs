using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody playerBody;
    public float jumpForce;
    public float moveSpeed;
    public bool onGround;
    public static bool playerDead;

	void Start ()
    {
        playerBody = GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
        if (!playerDead)
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                playerBody.position += new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0);
            }
            if (Input.GetAxis("Horizontal") == 0)
            { playerBody.velocity = new Vector2(0, playerBody.velocity.y); }
            if (Input.GetKeyDown(KeyCode.Space) && onGround)
            {
                playerBody.AddForce(Vector3.up * jumpForce);
            }
        }

        RaycastHit groundHit;
        Physics.Raycast(transform.position, Vector3.down, out groundHit, 0.7f);
        if (groundHit.collider != null)
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }

	}
}
