using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public AudioSource deathAudio;
    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        deathAudio = GetComponent<AudioSource>();
    }
    public void Death()
    {
        Destroy(gameObject);
        // deathAudio.Play();
        // Destroy(gameObject);
        // gameObject.transform.position = new Vector3(0, 0, 0);
    }

    public void jumpOn()
    {
        deathAudio.Play();
        animator.SetTrigger("death");
    }
}
