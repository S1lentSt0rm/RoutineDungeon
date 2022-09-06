using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PlayerAnimator : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Vector2 currentMovement = scr_InputManager.instance.playerInput.actions["Movement"].ReadValue<Vector2>();
        animator.SetBool("isRunning", currentMovement.magnitude > 0);
        
        FlipSprite(currentMovement);
    }
    void FlipSprite(Vector2 movement)
    {
        spriteRenderer.flipX = (movement.x < 0);
    }
}
