using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSonWhenTrigger : MonoBehaviour
{
    public Transform[] son;
    private void Awake()
    {
        son = GetComponentsInChildren<Transform>(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach (var item in son)
        {
            item.gameObject.SetActive(true);
        }
    }
}
