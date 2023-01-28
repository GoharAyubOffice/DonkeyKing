using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance;

    private GameObject _player;
    public GameObject gameOverUI;
    public GameObject restartUI;

    public bool gameStarted;

    public bool isGameOver = true;

    void Start()
    {
        gameStarted = false;
        if (gameManagerInstance == null)
        {
            gameManagerInstance = this;
        }

        _player = GameObject.Find("Player");

        _player.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameStarted = true;
            Time.timeScale = 1;
        }
        if(!gameStarted)
        {
            Time.timeScale = 0;
        }
    }
    public void Restart()
    {
        UIManager.uiManagerInstance.distance = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
