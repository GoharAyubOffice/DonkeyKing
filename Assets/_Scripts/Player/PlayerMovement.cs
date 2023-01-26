using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement playerInstance;
    [SerializeField] float _playerSpeed;
    [SerializeField] float _playerJumpVelocity = 10f;
    public float _springJumpForce;
    public float jumpHeight = 30f;


    public bool isGrounded = false;
    public bool isInAir = false;

    public float raycastDistance = 0.1f;
    public LayerMask whatIsGround;

    public Rigidbody rb;
    [SerializeField] float dragValue = 5;  //To slow down player in air
    [SerializeField] float dragValueDefault = 1;

    [SerializeField] Transform player;
    void Start()
    {
        if (playerInstance == null)
        {
            playerInstance = this;
        }
        rb = GetComponent<Rigidbody>();
        _springJumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y));
    }
    void FixedUpdate()
    {
        isGrounded = Physics.Raycast(player.position, Vector3.down, raycastDistance, whatIsGround);

        if (isGrounded)
        {
            isGrounded = true;
            NotInAir();
        }
        if (player.position.y > 3.5)
        {
            isInAir = true;
        }
    }
    void Update()
    {
        if (GameManager.gameManagerInstance.gameStarted == true)
        {
            Movement();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.LeftControl) && isInAir == true)
        {
            HoldInAir();
        }
        else
        {
            NotInAir();
        }
    }
    void Movement()
    {
        Vector3 velocity = new Vector3(_playerSpeed, 0, 0);
        rb.MovePosition(rb.position + velocity * Time.deltaTime);
    }
    void Jump()
    {
        rb.AddForce(Vector3.up * _playerJumpVelocity,ForceMode.Impulse);
        isGrounded = false;
    }
    void HoldInAir()
    {
        if (isInAir == true)
        {
            rb.drag = dragValue;
        }
    }
    void NotInAir()
    {
        rb.drag = dragValueDefault;
    }
}

