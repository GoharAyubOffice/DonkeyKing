using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _playerSpeed;
    [SerializeField] float _playerJumpVelocity = 10f;

    private bool isGrounded = false;
    public float raycastDistance = 0.1f;
    public LayerMask whatIsGround;

    private Rigidbody rb;

    [SerializeField] Transform player;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        isGrounded = Physics.Raycast(player.position, Vector3.down, raycastDistance, whatIsGround);
        Debug.DrawRay(player.position, Vector3.down * raycastDistance, Color.red);

        if(isGrounded)
        {
            isGrounded = true;
        }
    }
    void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Debug.Log("jUMPING");
            Jump();
        }
    }
    void Jump()
    {
        rb.AddForce(Vector3.up * _playerJumpVelocity, ForceMode.Impulse);
        isGrounded = false;
    }
    void Movement()
    {
        this.transform.Translate(Vector3.right * _playerSpeed * Time.deltaTime);
    }
}

