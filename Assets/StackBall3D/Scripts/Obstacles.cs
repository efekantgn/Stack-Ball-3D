using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Animations;

public class Obstacles : MonoBehaviour
{
    public Color obstacleColor;
    public float moveSpeed = 10f;
    private void Start()
    {
        GetComponent<Renderer>().material.color = obstacleColor;
        MoveUp();
    }

    [ContextMenu("MoveUp")]
    private void MoveUp()
    {
        transform.DOMoveY(10, 100 / moveSpeed);
    }
}
