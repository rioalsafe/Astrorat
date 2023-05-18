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
    public float spawnTime;     // ���� ���̺� �� ���� �ֱ�
    public int maxEnemyCount; // ���� ���̺� �� ���� ����
    public GameObject enemyPrefab;  // ���� ���̺� �� ���� ����
}
