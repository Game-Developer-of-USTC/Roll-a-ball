using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public Rigidbody2D rb;
	public LayerMask ground;
	public List<PhysicsMaterial2D> material2Ds;
	public List<int> masses;
	public List<int> gravity;
	public List<float> grab;
	public float force;
	public float jumpForce;
	public float dis;
	private bool jumpPressed;
	private bool isJumping;
	public float acclerationCoef;


	// Start is called before the first frame update
	void Start()
	{
		SwitchBall(1);
		isJumping = true;
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
		// float F = accleration * Force - sgn(rb.velocity.x) * rb.mass * rb.sharedMaterial.friction;
		// rb.velocity = new Vector2(rb.velocity.x + F / rb.mass * Time.deltaTime, rb.velocity.y);
		rb.AddRelativeForce(new Vector2(accleration * force, 0), ForceMode2D.Force);

		if (isOnGround())
			isJumping = false;
		if (isNearWall())
			isJumping = false;
		if (jumpPressed && isJumping == false)
		{
			// rb.velocity = new Vector2(rb.velocity.x, jumpForce / rb.mass * Time.deltaTime);
			rb.AddRelativeForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
			jumpPressed = false;
			isJumping = true;
		}
		jumpPressed = false;
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

	public void Death()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	bool isOnGround()
	{
		RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, dis, ground);
		Debug.DrawRay(transform.position, Vector2.down * dis, Color.green, 1);
		return ray;
	}

	bool isNearWall()
	{
		RaycastHit2D right = Physics2D.Raycast(transform.position, Vector2.right, dis, ground);
		Debug.DrawRay(transform.position, Vector2.right * dis, Color.green, 1);

		RaycastHit2D left = Physics2D.Raycast(transform.position, Vector2.left, dis, ground);
		Debug.DrawRay(transform.position, Vector2.left * dis, Color.green, 1);

		return right || left;
	}
}
