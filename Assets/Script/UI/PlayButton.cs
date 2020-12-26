using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject selectMenu;
    public void play()
    {
        selectMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
}
