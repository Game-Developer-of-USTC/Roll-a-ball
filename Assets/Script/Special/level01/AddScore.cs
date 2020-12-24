using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class AddScore : MonoBehaviour
{
    public TextMeshProUGUI text;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Collection")
        {
            Destroy(other.gameObject);
            int now = Int32.Parse(text.text);
            now = now + 1;
            text.text = now + "";
        }
    }
}
