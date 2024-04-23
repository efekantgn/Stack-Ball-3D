using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Obstacle>(out _))
        {
            GameManager.instance.OnGameEnded?.Invoke();
        }
    }
}
