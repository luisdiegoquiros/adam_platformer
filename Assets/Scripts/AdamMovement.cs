using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class AdamMovement : MonoBehaviour
{
    public LayerMask groundLayer;
    public float rayLength = 1.5f;

    private Rigidbody2D myRigidBody;

    public float playerSpeed = 8f;
    public float jumpSpeed = 8f;

    Vector2 moveInput;


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * playerSpeed, myRigidBody.velocity.y);

        myRigidBody.velocity = playerVelocity;
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed & IsGrounded())
        {
            myRigidBody.velocity += new Vector2(0f, jumpSpeed);

        }
    }

    private bool IsGrounded()
    {
        // Cast a ray straight down.
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.down, distance: rayLength, layerMask: groundLayer);



        Debug.DrawRay(this.transform.position, Vector2.down * rayLength, Color.red, duration:1f);

        return hit.collider != null;
    }
}
