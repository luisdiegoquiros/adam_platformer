using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AdamMovement : MonoBehaviour
{

    private Rigidbody2D myRigidBody;

    public float playerSpeed = 8f;

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

}
