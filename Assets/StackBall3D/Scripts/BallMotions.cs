using UnityEngine;
using DG.Tweening;

public class BallMotions : MonoBehaviour
{
    private BallMovement ballMovement;
    [SerializeField] private Vector3 RotateAmount;

    private void Start()
    {
        ballMovement = GetComponentInParent<BallMovement>();
        ballMovement.OnBallMoveLeft += OnBallMoveLeft;
        ballMovement.OnBallMoveRight += OnBallMoveRight;
    }
    private void Update()
    {
        transform.Rotate(RotateAmount * Time.deltaTime);
    }

    private void OnBallMoveRight()
    {
        transform.DOScale(Vector3.one * .5f, .05f).OnComplete(() => transform.DOScale(Vector3.one, .05f));
    }

    private void OnBallMoveLeft()
    {
        transform.DOScale(Vector3.one * .5f, .05f).OnComplete(() => transform.DOScale(Vector3.one, .05f));
    }
}
