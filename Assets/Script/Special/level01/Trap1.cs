using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Trap1 : MonoBehaviour
{
    public GameObject player;
    public LayerMask playerLayer;
    public float yOffset;
    void Awake()
    {
        player = GameObject.Find("/Player");
    }
    // Update is called once per frame
    void Update()
    {
        if (isPlayerBelow())
        {
            transform.position = new Vector2(transform.position.x,
            Math.Max(transform.position.y, player.transform.position.y + yOffset));
        }
    }

    bool isPlayerBelow()
    {
        RaycastHit2D right = Physics2D.Raycast(
            new Vector2(transform.position.x + 0.5f, transform.position.y),
            Vector2.down,
            yOffset + 1,
            playerLayer);
        RaycastHit2D left = Physics2D.Raycast(
            new Vector2(transform.position.x - 0.5f, transform.position.y),
            Vector2.down,
            yOffset + 1,
            playerLayer);

        return right || left;
    }
}
