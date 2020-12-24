using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAutoMove : MonoBehaviour
{
    public float velocity = 2.0f;
    public float rayDis = 0.7f;
    public LayerMask groundLayer;

    private void Awake()
    {
        groundLayer = LayerMask.GetMask("Ground");
    }
    private void FixedUpdate()
    {
        if (faceGround()) velocity *= -1;
        transform.position += new Vector3(velocity, 0, 0) * Time.deltaTime;
    }

    bool faceGround()
    {
        RaycastHit2D face = Physics2D.Raycast(
            transform.position,
            velocity > 0 ? Vector2.right : Vector2.left,
            rayDis,
            groundLayer);

        return face;
    }
}
