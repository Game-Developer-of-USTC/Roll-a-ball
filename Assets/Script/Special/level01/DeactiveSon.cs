using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveSon : MonoBehaviour
{
    Transform[] son;
    private void Awake()
    {
        son = GetComponentsInChildren<Transform>(true);
        foreach (var item in son)
        {
            item.gameObject.SetActive(false);
        }
        gameObject.SetActive(true);
    }
}
