using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanJumpThourghTile : MonoBehaviour
{
    public BoxCollider tileCollider;

    private void Start()
    {
        tileCollider = GetComponent<BoxCollider>();
    }
    private void Update()
    {
        if (PlayerMovement.playerInstance.isJumpThourghBottom == true)
        {
            tileCollider.isTrigger = true;
        }
        else
        {
            tileCollider.isTrigger = false;
        }
    }
}
