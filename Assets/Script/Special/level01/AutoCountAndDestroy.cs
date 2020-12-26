using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCountAndDestroy : MonoBehaviour
{
    public string countName;
    public float lifeTime;
    private void Awake()
    {
        PlayerPrefs.SetInt(countName, PlayerPrefs.GetInt(countName) + 1);
        Invoke("suicide", lifeTime);
    }

    void suicide()
    {
        PlayerPrefs.SetInt(countName, PlayerPrefs.GetInt(countName) - 1);
        Destroy(gameObject);
    }
}
