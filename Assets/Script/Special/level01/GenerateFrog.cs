using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFrog : MonoBehaviour
{
    public float deltaTime;
    public GameObject rightdownObject, leftupObject;
    private Vector3 rightdown, leftup;
    private float regenerateTime;
    public int generateNum;
    public int generateLim;
    public GameObject prefab;
    public string countName;
    private void Awake()
    {
        PlayerPrefs.SetInt(countName, 0);
        rightdown = rightdownObject.gameObject.transform.position;
        leftup = leftupObject.gameObject.transform.position;
    }

    private void FixedUpdate()
    {
        if (Time.time > regenerateTime)
        {
            for (int i = 0; i < generateNum &&
            PlayerPrefs.GetInt(countName) < generateLim; ++i)
                generate();
            regenerateTime = Time.time + deltaTime;
        }
    }

    void generate()
    {
        float x = Random.Range(leftup.x, rightdown.x);
        float y = Random.Range(rightdown.y + (leftup.y - rightdown.y) * 0.75f, leftup.y);

        GameObject gm = GameObject.Instantiate(prefab, new Vector3(x, y, 0), Quaternion.identity);

        PlayerPrefs.SetInt(countName, PlayerPrefs.GetInt(countName) + 1);
    }
}
