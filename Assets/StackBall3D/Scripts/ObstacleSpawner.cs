using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private const int DEFAULT_MOVE_SPEED = 10;
    private const float DEFAULT_SPAWN_TIMER = 2f;
    private float spawnerTime = DEFAULT_SPAWN_TIMER;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Obstacle obstacle;
    private Color obstacleColor = new Color(0, 0, 0);
    private float colorChanger = 0;
    private Coroutine spawner;
    private float moveSpeed = DEFAULT_MOVE_SPEED;
    public ObstaclePooling obstaclePooling;

    private void Awake()
    {
        obstaclePooling = GetComponent<ObstaclePooling>() ?? gameObject.AddComponent<ObstaclePooling>();
    }

    void Start()
    {
        obstaclePooling.obstacle = obstacle.gameObject;
        GameManager.instance.OnGameStarted += OnGameStart;
        GameManager.instance.OnGameEnded += OnGameEnd;
    }

    private void OnGameEnd()
    {
        StopCoroutine(spawner);
        obstaclePooling.SetAllObstaclesSetActive(false);
    }

    private void OnGameStart()
    {
        ResetValues();
        spawner = StartCoroutine(nameof(SpawnObstacles));
    }

    public IEnumerator SpawnObstacles()
    {
        while (GameManager.instance.GameState == GameManager.State.Started)
        {
            yield return new WaitForSeconds(spawnerTime);

            SetColor();
            moveSpeed = moveSpeed - (spawnerTime * 0.1f);
            spawnerTime = spawnerTime - (spawnerTime * 0.02f);
            int randRow = Random.Range(0, spawnPoints.Length);

            for (int i = 0; i <= spawnPoints.Length - 1; i++)
            {

                if (randRow == i) continue;

                Obstacle obstacle = obstaclePooling.InstantiateObstacle().GetComponent<Obstacle>();
                obstacle.gameObject.SetActive(true);
                obstacle.transform.SetParent(spawnPoints[i].transform);
                obstacle.transform.position = spawnPoints[i].transform.position;
                obstacle.obstacleSpawner = this;
                obstacle.MoveUp(moveSpeed);
                obstacle.SetColor(obstacleColor);
            }
        }
    }

    private void SetColor()
    {
        colorChanger += 0.1f;
        obstacleColor = new Color(colorChanger, colorChanger, colorChanger);
        if (colorChanger >= 1) colorChanger = 0;
    }

    public void ResetValues()
    {
        moveSpeed = DEFAULT_MOVE_SPEED;
        spawnerTime = DEFAULT_SPAWN_TIMER;
    }
}
