using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Pool;

public class Obstacle : MonoBehaviour
{
    private ObjectPool<Obstacle> _pool;
    public float moveSpeed = 10f;

    private void Start()
    {
        GameManager.instance.OnGameEnded += () =>
        {

        };
    }


    public void MoveUp()
    {
        transform.DOMoveY(10, 100 / moveSpeed).SetEase(Ease.Linear).OnComplete(() => ReleaseOnMoveEnd());
    }

    private void ReleaseOnMoveEnd()
    {
        _pool.Release(this);
    }

    public void SetColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
    }

    public void SetPool(ObjectPool<Obstacle> pool)
    {
        _pool = pool;
    }

}
