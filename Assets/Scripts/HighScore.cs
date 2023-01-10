using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    static public int score = 1000;
    private int pp_score;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            score = PlayerPrefs.GetInt("HighScore");
            pp_score = score;
        }
        PlayerPrefs.SetInt("HighScore", score);
    }
    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI gt = this.GetComponent<TextMeshProUGUI>();
        gt.text = $"High Score: {score}";
    }
    private void FixedUpdate()
    {
        if (score > pp_score)
        {
            pp_score = score;
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
