using UnityEngine;
using DG.Tweening;

public class BallMotions : MonoBehaviour
{
    private BallMovement ballMovement;

    private void Start()
    {
        ballMovement = GetComponentInParent<BallMovement>();
        ballMovement.OnBallMoveLeft += OnBallMoveLeft;
        ballMovement.OnBallMoveRight += OnBallMoveRight;
        Invoke(nameof(RotateBall), 0);
    }
    private void RotateBall()
    {
        transform.DORotate(Vector3.one * 180, 2f, RotateMode.Fast).SetLoops(-1).SetEase(Ease.Linear);
    }

    private void OnBallMoveRight()
    {
        transform.DOScale(Vector3.one * .5f, .1f).OnComplete(() => transform.DOScale(Vector3.one, .1f));
    }

    private void OnBallMoveLeft()
    {
        transform.DOScale(Vector3.one * .5f, .1f).OnComplete(() => transform.DOScale(Vector3.one, .1f));
    }
}
