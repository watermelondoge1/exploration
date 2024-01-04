using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Moving : MonoBehaviour
{
    [SerializeField] private float runSpeed = 11f;
    private Rigidbody rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;


        //cameraForward.y = 0f;
        // cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();


        Vector3 movement = cameraForward * moveInput.y + cameraRight * moveInput.x;
        Vector3 newVelocity = new Vector3(movement.x * runSpeed, rb.velocity.y, movement.z * runSpeed);

        rb.velocity = newVelocity;

    }
}
