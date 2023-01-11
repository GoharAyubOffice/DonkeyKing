using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _playerSpeed;
    [SerializeField] float _playerJumpVelocity = 10f;

    private bool isGrounded = false;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    void Update()
    {
        this.transform.Translate(Vector3.right * _playerSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, _playerJumpVelocity), ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
