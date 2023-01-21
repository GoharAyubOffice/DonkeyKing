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


    public bool isGameOver = true;

    void Start()
    {
        if (gameManagerInstance == null)
        {
            gameManagerInstance = this;
        }

        _player = GameObject.Find("Player");

        _player.gameObject.SetActive(true);
    }

    public void Restart()
    {
        UIManager.uiManagerInstance.currentTime = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
