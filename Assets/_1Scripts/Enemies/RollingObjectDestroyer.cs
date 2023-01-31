using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingObjectDestroyer : MonoBehaviour
{
    public Transform parentTransform;
    public float rollerLimit = 4;

    private void Update()
    {
        DestroyRollers();
    }
    void DestroyRollers()
    {
        if (parentTransform.childCount >= rollerLimit)
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
