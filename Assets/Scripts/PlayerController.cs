using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Vector2 moveInput;
    private PlayerInput playerInput;
    private Rigidbody2D rb;
    private Animator animator;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private bool paused = true;
    [SerializeField] private Image blackOverlay;
    [SerializeField] private TextMeshProUGUI overlayText;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!paused)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    public void StartGame(InputAction.CallbackContext context)
    {
        playerInput.SwitchCurrentActionMap("Gameplay");
        if(blackOverlay != null)
        {
            blackOverlay.color = new Color(0, 0, 0, 0);
        }
        if (overlayText != null)
        {
            overlayText.color = new Color(255, 255, 255, 0);
        }
        paused = false;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        animator.SetBool("Walking", true);

        if (context.canceled)
        {
            animator.SetBool("Walking", false);
            if(moveInput.x != 0)
            {
                animator.SetFloat("LastInputX", moveInput.x);
            }
        }
        moveInput = context.ReadValue<Vector2>();
        rb.linearVelocity = moveInput * speed;
        animator.SetFloat("InputX", moveInput.x);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        animator.SetBool("Attacking", true);
    }

    public void AttackEnd()
    {
        animator.SetBool("Attacking", false);
    }
}
