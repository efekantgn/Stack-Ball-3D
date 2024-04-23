using System;
using DG.Tweening;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed = 10f;
    public ObstacleSpawner obstacleSpawner;

    private void Start()
    {
        GameManager.instance.OnGameEnded += GameEnded;
    }

    private void GameEnded()
    {
        DOTween.Kill(this, true);
        transform.position = new Vector3(0, 0, 0);
    }

    public void MoveUp()
    {
        transform.DOMoveY(10, 100 / moveSpeed).SetEase(Ease.Linear).OnComplete(() => obstacleSpawner.obstaclePooling.UninstantiateObstacle(gameObject, 0));
    }

    public void SetColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
    }


}
