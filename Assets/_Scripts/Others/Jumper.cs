using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Spring Jump");
            PlayerMovement.playerInstance.rb.velocity = Vector3.zero;
            PlayerMovement.playerInstance.rb.AddForce(Vector3.up * PlayerMovement.playerInstance._springJumpForce, ForceMode.Impulse);
        }
    }
}
