using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeySetting : MonoBehaviour
{

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (SceneManager.GetActiveScene().buildIndex != 0)
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			else
				Application.Quit();
		}
	}
}