using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyChildTiles : MonoBehaviour
{
     public Transform parentTransform;
    public float tilesLimit = 6;
    private void Start()
    {
    parentTransform = GameObject.Find("TileParent").transform;
    }

    private void Update()
    {
        DestroyTiles();
    }
    void DestroyTiles()
    {
        if (parentTransform.childCount > tilesLimit)
        {
            // Use a for loop to iterate through the first five child GameObjects
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
