using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Spawner for testing enemies

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Transform Player1;

    [SerializeField]
    private Transform Player2;

    [SerializeField]
    private GameObject EnemyPrefab;

    [SerializeField]
    private float SpawnRate;

    private float SpawnCD;

    void Update()
    {
        // TESTING PURPOSES ONLY
        if (Time.time >= SpawnCD)
        {
            // change to meet enemy spawn methods

            var enemyObject = Instantiate(EnemyPrefab);
            enemyObject.transform.position = new Vector3(Random.Range(-20, 20), 4);

            ITarget<Transform> _target = enemyObject.GetComponent<ITarget<Transform>>();

            if (_target is ITarget<Transform>)
            {
                if (Vector2.Distance(enemyObject.transform.position, Player1.position) > Vector2.Distance(enemyObject.transform.position, Player2.position))
                {
                    _target.SetTarget(Player2);
                } else
                {
                    _target.SetTarget(Player1);
                }
            }

            SpawnCD = Time.time + SpawnRate;
        }
    }
}
