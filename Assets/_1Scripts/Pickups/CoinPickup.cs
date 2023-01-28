using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinPickup : MonoBehaviour
{
    public int scoreValue = 1; // the amount to increase the score by when a coin is picked up

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.uiManagerInstance.score += scoreValue;
            Destroy(this.gameObject);
        }
    }
}
