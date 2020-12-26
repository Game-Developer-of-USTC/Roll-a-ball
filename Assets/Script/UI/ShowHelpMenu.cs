using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHelpMenu : MonoBehaviour
{
    public GameObject go;
    public void show()
    {
        go.SetActive(true);
    }
    public void hide()
    {
        go.SetActive(false);
    }
}
