using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager uiManagerInstance;

    public int score;
    public TextMeshProUGUI coinsText;

    public TextMeshProUGUI timeText;

    public float distance = 0f;

    private void Start()
    {
        Time.timeScale = 0;

        score = 0;
        if(uiManagerInstance == null)
        {
            uiManagerInstance = this;
        }
    }
    private void Update()
    {
        //coinsText.text = "Coins: " + score.ToString(); // To show the Coins text
        coinsText.text = string.Format("Coins: {0}", score); // To show the Coins text

        //distance += PlayerMovement.playerInstance._playerSpeed * Time.deltaTime;  // calculating the distance with speed * time
        //timeText.text = "Distance:" + Mathf.RoundToInt(distance).ToString();
        distance += PlayerMovement.playerInstance._playerSpeed * Time.deltaTime;  // calculating the distance with speed * time
        timeText.text = string.Format("Distance: {0}", Mathf.RoundToInt(distance));
    }
}
