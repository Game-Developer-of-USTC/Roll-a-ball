using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject selectMenu;
    public void play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // selectMenu.SetActive(true);
        // mainMenu.SetActive(false);
    }
}
