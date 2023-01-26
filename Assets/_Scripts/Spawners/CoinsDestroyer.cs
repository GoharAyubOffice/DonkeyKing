using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsDestroyer : MonoBehaviour
{
    public Transform parentTransform;
    public float coinsLimit = 6;
    private void Start()
    {
        parentTransform = GameObject.Find("CoinsSpawner").transform;
    }
    private void Update()
    {
        DestroyTiles();
    }
    void DestroyTiles()
    {
        if (parentTransform.childCount > coinsLimit)
        {
            // Use a for loop to iterate through the first two child GameObjects
            for (int i = 0; i < 2; i++)
            {
                // Get the Transform component of the current child GameObject
                Transform childTransform = parentTransform.GetChild(i);
                // Destroy the current child GameObject
                Destroy(childTransform.gameObject);
            }
        }
    }
}
