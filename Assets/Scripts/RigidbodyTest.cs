using Palmmedia.ReportGenerator.Core.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class RigidbodyTest : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed;
    public float maxSpeed;
    public float jumpPower;
    public float rotateAngleSpeed;
    Vector3 dir;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(new Vector3(0, 0, dir.z)) * moveSpeed * Time.deltaTime);
        float angle = rotateAngleSpeed * Time.deltaTime;
        if (dir.z < 0)
        {
            angle *= -dir.x;
        }
        else
        {
            angle *= dir.x;
        }
        rb.rotation = transform.rotation * Quaternion.Euler(0, angle, 0);
    }

    private void OnMove(InputValue value)
    {
        float x = value.Get<Vector2>().x;
        float z = value.Get<Vector2>().y;
        dir.x = x;
        dir.z = z;
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            rb.AddRelativeForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }
}
