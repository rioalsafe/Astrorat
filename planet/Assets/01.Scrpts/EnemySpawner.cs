using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Wave[] waves;
    
    private Wave  currentWave;

    private void Awake()
    {
        currentWave = waves[0];
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        int enemyCount = 0;
        while (enemyCount < currentWave.maxEnemyCount)
        {
            GameObject clone = Instantiate(currentWave.enemyPrefab);
            OrbitMob orbitMob = clone.GetComponent<OrbitMob>();
            enemyCount++;
            yield return new WaitForSeconds(currentWave.spawnTime);
        }
    }
}
[System.Serializable]
public struct Wave
{
    public float spawnTime;     // 현재 웨이브 적 생성 주기
    public int maxEnemyCount; // 현재 웨이브 적 등장 숫자
    public GameObject enemyPrefab;  // 현재 웨이브 적 등장 종류
}
