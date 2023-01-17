using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Hurdle : MonoBehaviour
{
    public static Hurdle hurdleInstance;
    private GameObject _player;
    private void Start()
    {
        if (hurdleInstance == null)
        {
            hurdleInstance = this;
        }
        _player = GameObject.Find("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.gameManagerInstance.isGameOver = false;
            GameManager.gameManagerInstance.UI.gameObject.SetActive(true);
            _player.gameObject.SetActive(false);
        }
    }
}
