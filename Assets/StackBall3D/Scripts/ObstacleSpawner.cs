using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private float spawnerTime = 1f;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Obstacle obstacle;
    private Color obstacleColor = new Color(0, 0, 0);
    private float colorChanger = 0;
    private Coroutine spawner;
    private float moveSpeed = 10;
    public ObstaclePooling obstaclePooling;

    private void Awake()
    {
        obstaclePooling = GetComponent<ObstaclePooling>() ?? gameObject.AddComponent<ObstaclePooling>();
    }

    void Start()
    {
        obstaclePooling.obstacle = obstacle.gameObject;
        GameManager.instance.OnGameStarted += () =>
        {
            spawner = StartCoroutine(nameof(SpawnObstacles));
        }; ;
        GameManager.instance.OnGameEnded += () =>
        {
            StopCoroutine(spawner);
            obstaclePooling.SetAllObstaclesSetActive(false);
        }; ;
    }

    public IEnumerator SpawnObstacles()
    {
        while (GameManager.instance.GameState == GameManager.State.Started)
        {
            yield return new WaitForSeconds(spawnerTime);

            colorChanger += 0.1f;
            obstacleColor = new Color(colorChanger, colorChanger, colorChanger);
            if (colorChanger >= 1) colorChanger = 0;

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
}
