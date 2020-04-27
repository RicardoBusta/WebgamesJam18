using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameController controller;

    public bool endGame;

    private List<EnemyController> enemyPool;

    public EnemyController enemyPrefab;
    public bool paused;

    public PlayerController player;

    public float spawnDistance;

    public void Init()
    {
        enemyPool = new List<EnemyController>(100);
        for (var i = 0; i < 100; i++)
        {
            var enemy = Instantiate(enemyPrefab);
            enemy.target = player;
            enemy.gameObject.SetActive(false);
            enemy.controller = controller;
            enemyPool.Add(enemy);
        }

        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (!endGame)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnEnemy()
    {
        var angle = Random.Range(0, Mathf.PI * 2);
        var dir = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle)) * spawnDistance;
        var pos = player.transform.position - dir;
        pos.y = 0;
        var enemy = GetEnemy(pos, dir);
        enemy.Init();
    }

    private EnemyController GetEnemy(Vector3 position, Vector3 direction)
    {
        foreach (var e in enemyPool)
            if (!e.gameObject.activeSelf)
            {
                e.gameObject.SetActive(true);
                e.transform.position = position;
                e.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
                return e;
            }

        var enemy = Instantiate(enemyPrefab, position, Quaternion.LookRotation(direction, Vector3.up));
        enemy.target = player;
        enemy.controller = controller;
        return enemy;
    }
}