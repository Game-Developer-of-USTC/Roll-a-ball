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
        if (other.gameObject.tag == "Player")
        {
            if (player.transform.position.y < transform.position.y)
            {
                enemy.SetActive(true);
            }
        }
    }
}
