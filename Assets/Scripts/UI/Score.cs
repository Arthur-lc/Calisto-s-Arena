using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI txtmp;
    public TextMeshProUGUI bestTxtmp;
    public int score = 0;

    private void OnEnable() {
        Debug.Log("oi");
        score = GameManager.Instance.waveNumber - 1;
        txtmp.text = "Score: " + score;
        bestTxtmp.text = "Best Score: " + PlayerPrefs.GetInt("bestScore");

        if (PlayerPrefs.GetInt("bestScore") < score)
        {
            PlayerPrefs.SetInt("bestScore", score);
        }
        
    }
}
