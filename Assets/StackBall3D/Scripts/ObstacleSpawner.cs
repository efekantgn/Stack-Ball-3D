using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Obstacle obstacle;
    private Color obstacleColor = new Color(0, 0, 0);
    private float colorChanger = 0;
    private Coroutine spawner;

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
                Obstacle obstacle =
                obstacle.transform.SetParent(item.transform);
                obstacle.transform.position = item.transform.position;
                obstacle.MoveUp();
                obstacle.SetColor(obstacleColor);
            }
        }
    }
}
