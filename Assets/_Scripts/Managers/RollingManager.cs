using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingManager : MonoBehaviour
{
    public GameObject rollingObjectPrefab; // Drag your rolling animation object prefab here
    public float scoreThreshold; // The multiple of 10 at which the objects will spawn
    public float spawnDistance = 15f; // The distance in front of the player where the objects will spawn
    public Transform player; // Reference to the player's transform
    public Transform rollingobjectParent;

    [SerializeField] float rollerobjectsSpawnDelay = 10f;

    [SerializeField] bool isgeneratedRnumber = true;

    private void Start()
    {
        StartCoroutine(UpdateRandomValues());
    }
    void Update()
    {
        // Check if the player's score is greater than or equal to the score threshold
        if (UIManager.uiManagerInstance.score >= scoreThreshold && isgeneratedRnumber == true)
        {
            for (int i = 0; i < 2; i++)
            {
                // Spawn the rolling animation objects in front of the player
                Vector3 offset = new Vector3(i * 1, 0, 0); // Offset the position on the x-axis by 1 units for each iteration
                GameObject prefab = Instantiate(rollingObjectPrefab, player.position + player.right * spawnDistance + offset, Quaternion.identity);
                prefab.transform.SetParent(rollingobjectParent);
            }
            scoreThreshold += rollerobjectsSpawnDelay;

            isgeneratedRnumber = false;
        }
    }
    IEnumerator UpdateRandomValues()
    {
        while (isgeneratedRnumber)
        {
            yield return new WaitForSeconds(rollerobjectsSpawnDelay);
            isgeneratedRnumber = true;
        }
    }
}
