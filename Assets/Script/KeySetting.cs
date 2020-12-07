using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySetting : MonoBehaviour
{

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
	}
}
