using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallWhenTrigger : MonoBehaviour
{
    public float upLimit = 5.0f;
    public float downLimit = -10f;
    public float fallVelocity = 2.0f;
    public float velocity = 0f;
    private void FixedUpdate()
    {
        transform.position += new Vector3(0, velocity, 0) * Time.deltaTime;
        if (transform.position.y < downLimit)
            velocity = Mathf.Abs(velocity);
        if (transform.position.y > upLimit)
            velocity = Mathf.Abs(velocity) * -1;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            velocity = fallVelocity;
    }
}
