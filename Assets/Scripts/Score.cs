using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    private TextMeshProUGUI _scoreText;
    
    private int _score = 0;

    void Start()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
    }

    public void IncreaseScore(int amount)
    {
        _score += amount;
        _scoreText.text = "" + _score;
    }

    public void ResetScore()
    {
        _score = 0;
        _scoreText.text = "" + _score;
    }
}
