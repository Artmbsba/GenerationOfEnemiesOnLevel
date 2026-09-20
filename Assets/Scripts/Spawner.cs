using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _delay = 2.0f;

    private List<SpawnerPoint> _spawnerPoints = new List<SpawnerPoint>();

    private void Awake()
    {
        CollectAllSpawnerPoints();
    }

    private void Start()
    {
        StartCoroutine(DelaySpawnEnemy());
    }

    private IEnumerator DelaySpawnEnemy()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            yield return wait;

            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(_enemyPrefab, DefinePosition(), DefineRotation());
    }

    private void CollectAllSpawnerPoints()
    {
        _spawnerPoints.AddRange(GetComponentsInChildren<SpawnerPoint>());
    }

    private Quaternion DefineRotation()
    {
        float rotationDefault = 0;
        float maxRandomRotationY = 360;

        float randomTurn = Random.Range(rotationDefault, maxRandomRotationY);

        return Quaternion.Euler(rotationDefault, randomTurn, rotationDefault);
    }

    private Vector3 DefinePosition()
    {
        int minRandomNumberForSpawn = 0;
        int maxRandomNumberForSpawn = _spawnerPoints.Count;

        int numberSpawerPoint = Random.Range(minRandomNumberForSpawn, maxRandomNumberForSpawn);

        Bounds bounds = _spawnerPoints[numberSpawerPoint].Collider.bounds;

        return bounds.center;
    }
}
