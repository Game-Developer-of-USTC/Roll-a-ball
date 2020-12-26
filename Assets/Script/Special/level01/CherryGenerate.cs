using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryGenerate : MonoBehaviour
{
    public float deltaTime;
    public GameObject rightdownObject;
    public GameObject leftupObject;
    private Vector3 rightdown;
    private Vector3 leftup;
    private float regenerateTime;
    public int generateNum;
    public int generateLim;
    public GameObject cherryPrefab;
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
            Debug.Log("Generating!");
            for (int i = 0; i < generateNum && PlayerPrefs.GetInt(countName) < generateLim; ++i)
                generateCherry();
            regenerateTime = Time.time + deltaTime;
        }
    }

    void generateCherry()
    {
        float x = Random.Range(leftup.x, rightdown.x);
        float y = Random.Range(rightdown.y, leftup.y);

        GameObject cherry = GameObject.Instantiate(cherryPrefab, new Vector3(x, y, 0), Quaternion.identity);
        //TODO 添加碰撞检测
    }
}
