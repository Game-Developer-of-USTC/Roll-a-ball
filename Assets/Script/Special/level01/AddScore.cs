﻿using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class AddScore : MonoBehaviour
{
    private int bestScore;
    private string levelName;
    public TextMeshProUGUI scoreGUI;
    public TextMeshProUGUI bestScoreGUI;
    private void Awake()
    {
        levelName = SceneManager.GetActiveScene().name;
        int bestScore = PlayerPrefs.GetInt(levelName + "BestScore");
        bestScoreGUI.text = bestScore + "";
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Collection")
        {
            Destroy(other.gameObject);
            int now = Int32.Parse(scoreGUI.text);
            now = now + 1;
            scoreGUI.text = now + "";
            if (now > bestScore)
            {
                bestScore = now;
                bestScoreGUI.text = bestScore + "";
                PlayerPrefs.SetInt(levelName + "BestScore", bestScore);
            }
        }
    }
}
