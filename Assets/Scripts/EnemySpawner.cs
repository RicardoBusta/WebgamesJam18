using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public bool paused;

    public EnemyController enemyPrefab;

    public GameObject player;

    public void Init()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            var enemy = Instantiate(enemyPrefab);
            enemy.targetTransform = player.transform;
            yield return new WaitForSeconds(0.5f);
        }
    }
}