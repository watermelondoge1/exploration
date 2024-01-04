using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Looking : MonoBehaviour
{
    private Rigidbody rb;
    float rotationspeed = 0.2f;
    private Vector2 look = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
    }


    public void OnLook(InputValue value)
    {

        look += value.Get<Vector2>();
        look.y = Mathf.Clamp(look.y, -360f, 360f);
    }
    void Update()
    {

        Camera.main.transform.localRotation = Quaternion.Euler(-look.y * rotationspeed, 0, 0);
        rb.rotation = Quaternion.Euler(0, look.x * rotationspeed, 0);
    }
}
