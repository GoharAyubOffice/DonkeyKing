using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager uiManagerInstance;

    public int score;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        score = 0;
        if(uiManagerInstance == null)
        {
            uiManagerInstance = this;
        }
    }
    private void Update()
    {
        scoreText.text = "Coins: " + score.ToString();
    }
}
