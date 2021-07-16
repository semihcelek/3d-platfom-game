using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovementController : MonoBehaviour
{
    private Rigidbody rb;
    private float xInput, zInput;
    private bool isJumped;
    private bool isGrounded;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpForce = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        if(Input.GetButtonDown("Jump"))
        {
            isJumped = true;
        }
    }
    void FixedUpdate()
    { 
        Vector3 direction = new Vector3(xInput, 0, zInput).normalized;
        direction *= speed;

        rb.AddForce(direction, ForceMode.Acceleration);

        Ray ray = new Ray(transform.position,Vector3.down);

        if (Physics.Raycast(ray, transform.localScale.x / 2f + 0.01f))
        {
            isGrounded = true;
        } else
        {
            isGrounded = false;
        }

        if (isJumped && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumped = false;
        }

    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    isGrounded = true;
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    isGrounded = false;
    //}
}
