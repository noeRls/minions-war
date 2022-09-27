using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody body;
    [SerializeField]
    public float playerSpeed = 2.0f;
    [SerializeField]
    public float jumpForce = 100.0f;
    [SerializeField]
    private float distanceToGround;

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.1f);
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 newPos = transform.position + move * Time.deltaTime * playerSpeed;
        body.MovePosition(newPos);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            print("jump");
            body.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }
}
