using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public ObstacleSpawner obstacleSpawner;

    private void Start()
    {
        GameManager.instance.OnGameEnded += GameEnded;
    }

    private void GameEnded()
    {
        DOTween.Kill(transform, false);
    }

    public void MoveUp(float moveSpeed)
    {
        transform.DOMoveY(10, 100 / moveSpeed).SetEase(Ease.Linear).OnComplete(() => obstacleSpawner.obstaclePooling.UninstantiateObstacle(gameObject, 0));
    }

    public void SetColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
    }
}
