using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterLevel : MonoBehaviour
{
    public int levelID;
    public void enterLevel()
    {
        SceneManager.LoadScene(levelID);
    }
}
