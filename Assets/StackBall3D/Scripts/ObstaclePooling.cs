using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObstaclePooling : MonoBehaviour
{
    public GameObject obstacle;
    private List<GameObject> _pool = new List<GameObject>();

    public GameObject InstantiateObstacle()
    {
        for (int i = 0; i < _pool.Count; i++)
        {
            if (_pool[i] != null && !_pool[i].activeSelf)
            {
                return _pool[i];
            }
        }

        _pool.Add(Instantiate(obstacle));
        return _pool[_pool.Count - 1];
    }
    public void UninstantiateObstacle(GameObject obs, float duration)
    {
        StartCoroutine(UninstantiateObstacleNow(obs, duration));
    }
    IEnumerator UninstantiateObstacleNow(GameObject obs, float duration)
    {
        yield return new WaitForSeconds(duration);
        obs.SetActive(false);
    }

    public void SetAllObstaclesSetActive(bool isActive)
    {
        for (int i = 0; i < _pool.Count; i++)
        {
            _pool[i].SetActive(isActive);
        }
    }

}
