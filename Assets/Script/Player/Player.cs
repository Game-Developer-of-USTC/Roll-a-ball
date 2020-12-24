using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("辅助参数")]
    public Rigidbody2D rb;
    public LayerMask ground;
    [Header("三个球的参数")]
    public List<PhysicsMaterial2D> material2Ds;
    public List<float> masses;
    public List<float> gravity;
    public List<float> grab;
    [Header("跳跃参数")]
    public float moveForce;
    public float jumpForce;
    public float jumpHeld;
    public float jumpDuration;
    public float jumpTime;
    [Header("状态参数")]
    public float dis;
    public bool isJumpPressed;
    public bool isJumping;
    public bool isJumpHeld;
    private bool isGround;

    // Start is called before the first frame update
    void Start()
    {
        SwitchBall(1);
    }

    // 更新状态
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) SwitchBall(0);
        else if (Input.GetKeyDown(KeyCode.W)) SwitchBall(1);
        else if (Input.GetKeyDown(KeyCode.E)) SwitchBall(2);

        if (Input.GetButtonDown("Jump"))
            isJumpPressed = true;
        isJumpHeld = Input.GetButton("Jump");
        isGround = isOnGround();
    }

    void FixedUpdate()
    {
        horizontalMove();
        jumpMove();
    }

    void horizontalMove()
    {
        float accleration = Input.GetAxis("Horizontal");
        // float F = accleration * Force - sgn(rb.velocity.x) * rb.mass * rb.sharedMaterial.friction;
        // rb.velocity = new Vector2(rb.velocity.x + F / rb.mass * Time.deltaTime, rb.velocity.y);
        rb.AddRelativeForce(new Vector2(accleration * moveForce, 0), ForceMode2D.Force);
    }

    void jumpMove()
    {
        if (isJumpPressed && isJumping == false && isGround)
        {
            // rb.velocity = new Vector2(rb.velocity.x, jumpForce / rb.mass * Time.deltaTime);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumpTime = Time.time + jumpDuration;
            isJumping = true;
            isJumpPressed = false;
        }
        else if (isJumping)
        {
            if (isJumpHeld)
                rb.AddForce(new Vector2(0f, jumpHeld), ForceMode2D.Impulse);
            if (jumpTime < Time.time)
                isJumping = false;
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

    private void OnCollisionEnter2D(Collision2D other)
    {

    }
}
