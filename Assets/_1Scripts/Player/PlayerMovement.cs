using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement playerInstance;

    [Header("Player Information")]

    [SerializeField] public float _playerSpeed;

    [SerializeField] float _playerJumpVelocity = 10f;

    [SerializeField] float _swipeDownVelocity = 5;
    public float _playerDashForce = 10f;

    public float _springJumpForce;

    public float jumpHeight = 30f;

    public float raycastDistance = 0.1f;

    public LayerMask whatIsGround;

    public float raycastDistanceBottom = 0.2f;

    public bool isGrounded = false;

    public bool isJumpThourghBottom = false;

    public bool isInAir = false;

    public bool isCrouching;

    [Header("Player RB Information")]

    public Rigidbody rb;
    [SerializeField] float dragValue = 5;  //To slow down player in air
    [SerializeField] float dragValueDefault = 1;

    public Transform player;
    [SerializeField] Transform playerHead;

    [Header("Player Collider Information")]

    public BoxCollider _playerBoxCollider;

    [Header("Player Animation Information")]

    public Animator playerAnim;

    void Start()
    {
        isCrouching = false;

        if (playerInstance == null)
        {
            playerInstance = this;
        }
        rb = GetComponent<Rigidbody>();
        _playerBoxCollider = GetComponent<BoxCollider>();
        playerAnim.GetComponent<Animator>();

        _springJumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y));
    }
    void FixedUpdate()
    {
        isGrounded = Physics.Raycast(player.position, Vector3.down, raycastDistance, whatIsGround);

        isJumpThourghBottom = Physics.Raycast(player.position, Vector3.up, raycastDistanceBottom, whatIsGround);

        Debug.DrawRay(player.position, Vector3.up * raycastDistanceBottom, Color.red);

        if (isGrounded)
        {
            //if is grounded than hold false
            playerAnim.SetBool("isHold", false);

            isGrounded = true;
            isInAir = false;
            NotInAir();
        }

        if(!isGrounded)
        {
            isInAir = true;
        }
        
        /*if(isInAir == true)
        {
            playerAnim.SetBool("isJump", true);
        }*/

        if (isJumpThourghBottom)
        {
            isJumpThourghBottom = true;
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
        if (Input.GetKeyDown(KeyCode.C))
        {
            Crouch();
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

        // Run Animation
        playerAnim.SetBool("isRun", true);
        if (isGrounded)
        {
            playerAnim.SetBool("isJump", false);
        }
        /*if (!isGrounded)
        {
            playerAnim.SetBool("isJump", true);
        }*/
    }
    void Jump()
    {
        rb.AddForce(Vector3.up * _playerJumpVelocity, ForceMode.Impulse);

        isGrounded = false;
        // Jump Animation
        playerAnim.SetBool("isJump", true);
    }
    void Crouch()
    {
        rb.AddForce(Vector3.down * _swipeDownVelocity, ForceMode.Impulse);

        isCrouching = true;
    }
    void HoldInAir()
    {
        playerAnim.SetBool("isHold", true);
        if (isInAir == true)
        {
            rb.drag = dragValue;
        }
    }
    void NotInAir()
    {
        rb.drag = dragValueDefault;
        playerAnim.SetBool("isHold", false);
    }
}

