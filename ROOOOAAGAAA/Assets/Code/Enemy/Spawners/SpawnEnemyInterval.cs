using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyInterval : MonoBehaviour
{
    [SerializeField]
    private GameObject EnemyPrefab;

    [SerializeField]
    private float SpawnRate;

    [SerializeField]
    private float yOffset;

    [SerializeField]
    private float Range;

    [SerializeField]
    private float DelayToStart;

    private float _SpawnCD;

    private void Awake()
    {
        _SpawnCD = Time.time + DelayToStart;
    }

    private void Update()
    {
        if (Time.time <= _SpawnCD) return;

        var enemyObject = Instantiate(EnemyPrefab);
        enemyObject.transform.position = new Vector3(Random.Range(-Range, Range), yOffset);

        _SpawnCD = Time.time + SpawnRate;
    }
}
