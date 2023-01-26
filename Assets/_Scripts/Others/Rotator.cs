using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 1f;
    private Rigidbody rollerRB;
    [SerializeField] float rollerSpeed = 1f;

    private void Start()
    {
        rollerRB = GetComponent<Rigidbody>();
    }
    void Update()
    {
        this.transform.Rotate(new Vector3(0, 0, 90) * rotationSpeed * Time.deltaTime);
        rollerRB.AddForce(Vector3.left * rollerSpeed * Time.deltaTime, ForceMode.Impulse);
    }
}
