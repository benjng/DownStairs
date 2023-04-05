using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Character : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float characterGravity = 1.1f;
    [SerializeField] private GameObject UI;

    private Rigidbody2D rb;
    private Animator Animator;
    private string currentState = "isIdle";
    private int xInput;
    private bool isFalling = true;
    private bool gameStarted = false;
    private float ScreenLx, ScreenRx;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        Animator = GetComponent<Animator>();
        Animator.SetTrigger("startFalling");
        ScreenLx = -Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        ScreenRx = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
    }

    private void AnimationStateController(float xInput)
    {
        if (rb.velocity.y < -0.5)
        {
            if (isFalling) return;
            Animator.SetTrigger("startFalling");
            isFalling = true;
            return;
        }
        isFalling = false;

        string newState;
        if (xInput < 0)
        {
            newState = "isWalkingLeft";
        }
        else if (xInput > 0)
        {
            newState = "isWalkingRight";
        }
        else
        {
            newState = "isIdle";
        }
        
        if (newState == currentState)
        {
            return;
        }
        Animator.SetBool(currentState, false);
        Animator.SetBool(newState, true);
        currentState = newState;
    }

    void FixedUpdate()
    {
        if (!gameStarted)
        {
            gameStarted = UI.GetComponent<UI>().gameStarted;
            return;
        }
        if (rb.gravityScale == 0)
        {
            rb.gravityScale = characterGravity;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x > Screen.width/2)
            {
                xInput = 1;
            } else
            {
                xInput = -1;
            }
        } else
        {
            xInput = 0;
        }
        AnimationStateController(xInput);

        float currentMovement = xInput * moveSpeed * Time.fixedDeltaTime;
        transform.position += new Vector3(currentMovement, 0, 0);
        
        if (transform.position.x < ScreenLx)
        {
            transform.position = new Vector3(ScreenRx, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > ScreenRx)
        {
            transform.position = new Vector3(ScreenLx, transform.position.y, transform.position.z);
        }

        // When character touching bottom
        if (transform.position.y <= -Camera.main.orthographicSize)
        {
            //SceneManager.LoadScene(2);
        }
    }
}