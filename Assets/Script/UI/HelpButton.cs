using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpButton : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject helpPanel;
    public void help()
    {
        //SceneManager.LoadScene(SceneManager.GetSceneByName("Help").buildIndex);
        helpPanel.SetActive(true);
        mainMenu.SetActive(false);
    }
}
