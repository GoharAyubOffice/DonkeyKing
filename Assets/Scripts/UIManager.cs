using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager uiManagerInstance;

    public int score;
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI timeText;

    public float currentTime = 0f;

    private void Start()
    {
        Time.timeScale = 1;

        score = 0;
        if(uiManagerInstance == null)
        {
            uiManagerInstance = this;
        }
    }
    private void Update()
    {
        scoreText.text = "Coins: " + score.ToString(); // To show the Coins text

        currentTime += Time.deltaTime;
        timeText.text = "Score:" + Mathf.RoundToInt(currentTime).ToString();
    }
    
}
