using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Rigidbody2D rb;
	public CircleCollider2D cc;
	public LayerMask ground;
	public List<PhysicsMaterial2D> material2Ds;
	public List<int> masses;
	public List<int> gravity;
	public float Force;
	public float jumpForce;

	private bool jumpPressed;
	private bool isJumping;


	// Start is called before the first frame update
	void Start()
	{
		SwitchBall(1);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q)) SwitchBall(0);
		else if (Input.GetKeyDown(KeyCode.W)) SwitchBall(1);
		else if (Input.GetKeyDown(KeyCode.E)) SwitchBall(2);

		if (Input.GetButtonDown("Jump"))
			jumpPressed = true;
	}

	void FixedUpdate()
	{
		float accleration = Input.GetAxis("Horizontal");
		float F = accleration * Force - sgn(rb.velocity.x) * rb.mass * rb.sharedMaterial.friction;
		rb.velocity = new Vector2(rb.velocity.x + F / rb.mass * Time.deltaTime, rb.velocity.y);

		if (rb.IsTouchingLayers(ground))
			isJumping = false;
		if (jumpPressed && isJumping == false)
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpForce / rb.mass * Time.deltaTime);
			jumpPressed = false;
			isJumping = true;
		}
	}
	int sgn(float x)
	{
		if (x < 0) return -1;
		if (x > 0) return 1;
		return 0;
	}

	void SwitchBall(int ball)
	{
		rb.mass = masses[ball];
		rb.gravityScale = gravity[ball];
		switchMaterial(material2Ds[ball]);
	}

	void switchMaterial(PhysicsMaterial2D m)
	{
		rb.sharedMaterial = m;
	}
}
