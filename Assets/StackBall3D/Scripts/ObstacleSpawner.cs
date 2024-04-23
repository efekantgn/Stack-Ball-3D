using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Obstacle obstacle;
    private Color obstacleColor = new Color(0, 0, 0);
    private float colorChanger = 0;
    private ObjectPool<Obstacle> _pool;
    private Coroutine spawner;

    private void Awake()
    {
        _pool = new ObjectPool<Obstacle>(CreateBullet, OnTakeObstacleFromPool, OnReturnObstacleToPool, OnDestroyObstacle, true, 10, 1000);
    }

    private void OnDestroyObstacle(Obstacle obstacle)
    {
        Destroy(obstacle.gameObject);
    }

    public void OnReturnObstacleToPool(Obstacle obstacle)
    {
        obstacle.gameObject.SetActive(false);
    }
    private void OnTakeObstacleFromPool(Obstacle obstacle)
    {
        obstacle.gameObject.SetActive(true);
    }

    private Obstacle CreateBullet()
    {
        Obstacle obstacles = Instantiate(obstacle);
        obstacles.SetPool(_pool);
        return obstacles;
    }

    void Start()
    {
        GameManager.instance.OnGameStarted += () =>
        {
            spawner = StartCoroutine(nameof(SpawnObstacles));
        }; ;
        GameManager.instance.OnGameEnded += () =>
        {
            StopCoroutine(spawner);
        }; ;
    }

    public IEnumerator SpawnObstacles()
    {
        while (GameManager.instance.GameState == GameManager.State.Started)
        {
            yield return new WaitForSeconds(1f);
            colorChanger += 0.1f;
            obstacleColor = new Color(colorChanger, colorChanger, colorChanger);
            if (colorChanger >= 1) colorChanger = 0;

            foreach (var item in spawnPoints)
            {
                Obstacle obstacle = _pool.Get();
                obstacle.transform.SetParent(item.transform);
                obstacle.transform.position = item.transform.position;
                obstacle.MoveUp();
                obstacle.SetColor(obstacleColor);
            }
            Debug.Log("a");
        }
    }
}
