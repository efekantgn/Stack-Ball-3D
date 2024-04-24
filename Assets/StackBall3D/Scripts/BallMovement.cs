using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using TouchPhase = UnityEngine.TouchPhase;

public class BallMovement : MonoBehaviour
{
    private const float DEFAULT_MOV_MULT = 3f;
    private float movementMultiplier = DEFAULT_MOV_MULT;
    private Vector2 startTouchPos = Vector2.zero;
    private Vector2 endTouchPos = Vector2.zero;
    public Action OnBallMoveLeft;
    public Action OnBallMoveRight;

    private void Start()
    {
        GameManager.instance.OnGameEnded += () => movementMultiplier = 0;
        GameManager.instance.OnGameStarted += () => movementMultiplier = DEFAULT_MOV_MULT;
    }
    private void Update()
    {
        if (GameManager.instance.GameState != GameManager.State.Started) return;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPos = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPos = Input.GetTouch(0).position;

            if (endTouchPos.x < startTouchPos.x && transform.position.x > -5)
            {
                MoveLeft();
            }
            if (endTouchPos.x > startTouchPos.x && transform.position.x < 5)
            {
                MoveRight();
            }
        }

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
        OnBallMoveRight?.Invoke();
        //transform.position += Vector3.right * movementMultiplier;
        float endXpos = transform.position.x + movementMultiplier;
        transform.DOMoveX(endXpos, .2f);
    }

    private void MoveLeft()
    {
        OnBallMoveLeft?.Invoke();
        //transform.position += Vector3.left * movementMultiplier;
        float endXpos = transform.position.x - movementMultiplier;
        transform.DOMoveX(endXpos, .2f);
    }
}
