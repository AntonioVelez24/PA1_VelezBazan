using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    private float xDirection;
    private float zDirection;
    private int speed = 8;
    public int health = 10;
    public int score;
    private Rigidbody _compRigidbody;
    bool jump;
    private int verticalForce = 6;
    bool jumping;
    public static event Action<int> OnPlayerScore;
    private void Awake()
    {
        _compRigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        if (jump)
        {
            jump = false;
            jumping = true;
            _compRigidbody.AddForce(Vector3.up * verticalForce, ForceMode.Impulse);
        }
        _compRigidbody.velocity = new Vector3(speed * xDirection, _compRigidbody.velocity.y, speed * zDirection);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            score = score + 100;
            OnPlayerScore?.Invoke(score);
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumping = false;
        }
        if (collision.gameObject.CompareTag("lava"))
        {
            Destroy(gameObject);
        }
    }
    public void ReadJump(InputAction.CallbackContext context)
    {
        if (context.performed && jumping == false) 
        {
            jump = true;
        }
    }
    public void ReadMovementX (InputAction.CallbackContext context)
    {
        xDirection = context.ReadValue<float>();
    }
    public void ReadMovementZ(InputAction.CallbackContext context)
    {
        zDirection = context.ReadValue<float>();
    }
}
