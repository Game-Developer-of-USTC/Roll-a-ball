using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressESCtoBack : MonoBehaviour
{
    public GameObject go;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            go.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
