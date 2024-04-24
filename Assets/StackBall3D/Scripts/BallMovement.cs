using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallMovement : MonoBehaviour
{
    private const float DEFAULT_MOV_MULT = 3f;
    private float movementMultiplier = DEFAULT_MOV_MULT;

    private void Start()
    {
        GameManager.instance.OnGameEnded += () => movementMultiplier = 0;
        GameManager.instance.OnGameStarted += () => movementMultiplier = DEFAULT_MOV_MULT;
    }
    private void Update()
    {
        if (GameManager.instance.GameState != GameManager.State.Started) return;

        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > -5)
        {
            MoveLeft();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < 5)
        {
            MoveRight();
        }
    }

    private void MoveRight()
    {
        transform.position += Vector3.right * movementMultiplier;
    }

    private void MoveLeft()
    {
        transform.position += Vector3.left * movementMultiplier;
    }
}
