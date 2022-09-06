using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class scr_InputManager : MonoBehaviour
{
    public static scr_InputManager instance = null;

    public PlayerInput playerInput;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        playerInput = GetComponent<PlayerInput>();
        playerInput.actions.FindActionMap("Game").Enable();
        //playerInput.actions.FindActionMap("UI").Enable();
        //playerInput.actions.FindActionMap("UI1").Enable();
    }
}
