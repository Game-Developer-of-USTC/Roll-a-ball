using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap2 : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    private void Awake()
    {
        player = GameObject.Find("/Player");
    }
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collided");
        if (other.gameObject.tag == "Player")
        {
            // if (checkPlayerBelow())
            {
                if (enemy)
                    enemy.SetActive(true);
            }
        }
    }

    public bool checkPlayerBelow()
    {
        RaycastHit2D left = Physics2D.Raycast(
        transform.position + new Vector3(-0.5f, 0, 0),
        Vector2.down,
        10);

        RaycastHit2D right = Physics2D.Raycast(
        transform.position + new Vector3(+0.5f, 0, 0),
        Vector2.down,
        10);

        Debug.Log(left);
        Debug.Log(right);
        return (left && left.collider.tag == "Player") ||
                (right && right.collider.tag == "Player");
    }

    private void Update()
    {
        Debug.DrawRay(
            transform.position + new Vector3(-0.5f, 0, 0),
            10 * Vector2.down
        );

        Debug.DrawRay(
            transform.position + new Vector3(+0.5f, 0, 0),
            10 * Vector2.down
        );
    }
}
