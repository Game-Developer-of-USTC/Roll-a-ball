﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deadline : MonoBehaviour
{
	public Player player;
	public BoxCollider2D coll;
	// Update is called once per frame

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			player.Death();
		}
	}
}
