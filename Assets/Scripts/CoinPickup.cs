using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinPickup : MonoBehaviour
{
    public int coinsScore = 10;
    public TextMeshProUGUI coinsText;

    private void Start()
    {
        coinsText = GetComponent<TextMeshProUGUI>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            coinsText.text = coinsScore.ToString();
        }
    }
}
