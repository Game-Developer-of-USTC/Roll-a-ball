using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BecamePoisonWhenTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.AddComponent<Poison>();
    }
}
