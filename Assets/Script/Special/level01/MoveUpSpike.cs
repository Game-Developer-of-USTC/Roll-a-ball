using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpSpike : MonoBehaviour
{
    public float upLimit = 5f;
    public float downLimit = -10f;
    public float afterVelocity = 2.0f;
    public float velocity = 0.0f;
    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position = transform.position +
                            new Vector3(0, velocity, 0) * Time.deltaTime;
        if (transform.position.y < downLimit)
            velocity = Mathf.Abs(velocity);
        if (transform.position.y > upLimit)
            velocity = Mathf.Abs(velocity) * -1;
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
        if (other.gameObject.tag == "Player")
            velocity = afterVelocity;
    }
}
