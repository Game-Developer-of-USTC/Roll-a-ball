using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("辅助参数")]
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public LayerMask ground;
    [Header("三个球的参数")]
    public List<float> masses;
    public List<float> gravity;
    public List<float> grab;
    public List<Sprite> sprites;
    [Header("跳跃参数")]
    public float moveForce;
    public float jumpForce;
    public float jumpHeld;
    public float jumpDuration;
    public float jumpTime;
    public int jumpCount;
    private int initCount;
    public Transform groundCheck;
    [Header("状态参数")]
    public float dis;
    public bool isJumpPressed;
    public bool isJumping;
    public bool isJumpHeld;
    public bool isGround;
    [Header("动画参数")]
    public Animator anim;
    [Header("音乐参数")]
    public AudioSource audioSource;

    private void Awake()
    {
        initCount = jumpCount;
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
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

        if (Input.GetButtonDown("Jump") && jumpCount > 0)
            isJumpPressed = true;
        // isJumpHeld = Input.GetButton("Jump");
        // isGround = isOnGround();
    }

    void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);
        horizontalMove();
        jumpMove();
    }

    void horizontalMove()
    {
        float accleration = Input.GetAxis("Horizontal");
        // float F = accleration * Force - sgn(rb.velocity.x) * rb.mass * rb.sharedMaterial.friction;
        // rb.velocity = new Vector2(rb.velocity.x + F / rb.mass * Time.deltaTime, rb.velocity.y);
        // rb.AddRelativeForce(new Vector2(accleration * moveForce, 0), ForceMode2D.Force);
        rb.velocity = new Vector2(accleration * moveForce, rb.velocity.y);
    }

    void jumpMove()
    {
        #region 按得越久跳的越高的方法
        // if (isJumpPressed && isJumping == false && isGround)
        // {
        //     // rb.velocity = new Vector2(rb.velocity.x, jumpForce / rb.mass * Time.deltaTime);
        //     rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        //     // rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        //     jumpTime = Time.time + jumpDuration;
        //     isJumping = true;
        //     isJumpPressed = false;
        // }
        // else if (isJumping)
        // {
        //     if (isJumpHeld)
        //     {
        //         // rb.velocity = new Vector2(rb.velocity.x, jumpHeld);
        //         rb.AddForce(new Vector2(0f, jumpHeld), ForceMode2D.Impulse);
        //     }
        //     if (jumpTime < Time.time)
        //         isJumping = false;
        // }
        #endregion

        #region 多段跳跃的方法
        if (isGround)
        {
            jumpCount = initCount;
            isJumping = false;
        }
        if (isJumpPressed && isGround)
        {
            isJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
            isJumpPressed = false;
        }
        else if (isJumpPressed && jumpCount > 0 && isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
            isJumpPressed = false;
        }
        #endregion
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
        sr.sprite = sprites[ball];
    }
    public void reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // Destroy(gameObject);
    }
    public void Death()
    {
        audioSource.Play();
        // rb = null;
        Collider2D coll = GetComponent<Collider2D>();
        coll = null;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        anim.SetTrigger("death");
        GetComponent<SpriteRenderer>().sprite = null;
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
