using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleZeroWhenAwake : MonoBehaviour
{
    private void Awake()
    {
        transform.localScale = new Vector3(0, 0, 0);
    }
}
