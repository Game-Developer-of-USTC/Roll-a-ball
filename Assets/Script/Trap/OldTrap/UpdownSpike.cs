using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdownSpike : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform up, down;
    public float speed;
    private float upy, downy;
    private int dir = -1;

    // Start is called before the first frame update
    void Start()
    {
        upy = up.position.y;
        downy = down.position.y;
        transform.DetachChildren();
        Destroy(up.gameObject);
        Destroy(down.gameObject);
        Debug.Log(rb.position.y);
        Debug.Log(upy);
        Debug.Log(downy);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (rb.position.y < downy) dir = 1;
        if (rb.position.y > upy) dir = -1;
        rb.velocity = new Vector2(rb.velocity.x, dir * speed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().Death();
        }
    }
}
