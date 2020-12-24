using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenBlock : MonoBehaviour
{
    public Sprite initSprite;
    private void Awake()
    {
        initSprite = GetComponent<SpriteRenderer>().sprite;
        GetComponent<SpriteRenderer>().sprite = null;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GetComponent<SpriteRenderer>().sprite = initSprite;
    }
}
