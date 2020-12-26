using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioSource deathAudio;
    protected void Awake()
    {
        deathAudio = GetComponent<AudioSource>();
    }
    public void Death()
    {
        deathAudio.Play();
        // Destroy(gameObject);
        gameObject.transform.position = new Vector3(0, 0, 0);
    }
}
