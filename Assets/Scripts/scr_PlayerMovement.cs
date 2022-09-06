using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class scr_PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] private float moveSpeed = 5f;
    [Range(0, .3f)][SerializeField] private float movementSmoothing = .01f;

    scr_InputManager inputManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        inputManager = scr_InputManager.instance;
    }

    void FixedUpdate()
    {
        Vector2 moveDirection = inputManager.playerInput.actions["Movement"].ReadValue<Vector2>();

        Move(rb, moveDirection, moveSpeed, movementSmoothing);
    }

    public void Move(Rigidbody2D rb, Vector2 moveDirection, float moveSpeed, float movementSmoothing)
    {
        Vector2 velocity = Vector2.zero;
        Vector2 targetVelocity;
        targetVelocity = new Vector3(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);
    }
}
