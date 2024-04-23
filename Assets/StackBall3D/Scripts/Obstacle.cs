using DG.Tweening;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed = 10f;

    public void MoveUp()
    {
        transform.DOMoveY(10, 100 / moveSpeed).SetEase(Ease.Linear);
    }

    public void SetColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
    }


}
