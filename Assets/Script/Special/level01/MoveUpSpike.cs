using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpSpike : MonoBehaviour
{
    public float afterVelocity = 2.0f;
    public float velocity = 0.0f;
    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position = transform.position +
                            new Vector3(0, velocity, 0) * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().Death();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        velocity = afterVelocity;
    }
}
