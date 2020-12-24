using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy1 : MonoBehaviour
{
    public float velocity;
    public Rigidbody2D rb;
    public float rayDis = 0.7f;
    public LayerMask groundLayer;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocity, rb.velocity.y);

        if (rb.velocity.x > 0)
            transform.localScale = new Vector3(
                -System.Math.Abs(transform.localScale.x),
                transform.localScale.y,
                transform.localScale.z);
        else
            transform.localScale = new Vector3(
     System.Math.Abs(transform.localScale.x),
     transform.localScale.y,
     transform.localScale.z);

        RaycastHit2D face = Physics2D.Raycast(
            transform.position, velocity > 0 ? Vector2.right : Vector2.left,
            rayDis,
            groundLayer);
        if (face) velocity = -velocity;
    }
}
