﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AutoMoveFrog : Enemy
{
    public float velocity;
    public Rigidbody2D rb;
    public float rayDis = 0.7f;
    protected override void Awake()
    {
        if (UnityEngine.Random.Range(-1, 1) > 0)
            velocity *= -1;
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocity, rb.velocity.y);

        if (rb.velocity.x > 0)
            transform.localScale = new Vector3(
                -System.Math.Abs(transform.localScale.x),
                transform.localScale.y,
                transform.localScale.
                z);
        else
            transform.localScale = new Vector3(
                System.Math.Abs(transform.localScale.x),
                transform.localScale.y,
                transform.localScale.z
                );

        //RaycastHit2D face = Physics2D.Raycast(
        //    transform.position,
        //    velocity > 0 ? Vector2.right : Vector2.left,
        //    rayDis,
        //    groundLayer);
        //if (face) velocity = -velocity;

        Debug.DrawRay(
            transform.position + new Vector3(-0.5f, 0.5f, 0),
            10 * Vector2.up,
            Color.green
        );

        Debug.DrawRay(
            transform.position + new Vector3(+0.5f, 0.5f, 0),
            10 * Vector2.up,
            Color.green
        );
    }

    private void FixedUpdate()
    {
        RaycastHit2D[] face = Physics2D.RaycastAll(
            transform.position,
            velocity > 0 ? Vector2.right : Vector2.left,
            rayDis);
        foreach (var item in face)
        {
            if ((item.collider.gameObject.tag == "Enemy" || item.collider.gameObject.tag == "Ground") && item.collider.gameObject != this.gameObject)
            {
                velocity *= -1;
                break;
            }
        }
        Debug.DrawRay(
            transform.position,
            rayDis * (velocity > 0 ? Vector2.right : Vector2.left)
        );
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<Rigidbody2D>().velocity.y < -0.1f)
            {
                Player player = other.gameObject.GetComponent<Player>();
                player.rb.velocity = new Vector2(player.rb.velocity.x, player.jumpForce);
                base.jumpOn();
                return;
            }
            other.gameObject.GetComponent<Player>().Death();
        }
    }
}

