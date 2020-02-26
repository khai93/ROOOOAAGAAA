using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Spawner for testing enemies

public class SpawnEnemyIntervalTargetClosest : MonoBehaviour
{
    [SerializeField]
    private GameObject EnemyPrefab;

    [SerializeField]
    private float SpawnRate;

    [SerializeField]
    private float yOffset;

    private float SpawnCD;

    private void Update()
    {
        if (Time.time >= SpawnCD)
        {
            var enemyObject = Instantiate(EnemyPrefab);
            enemyObject.transform.position = new Vector3(Random.Range(-20, 20), yOffset);

            ITarget<Transform> _target = enemyObject.GetComponent<ITarget<Transform>>();

            if (_target != null)
            {
                Transform closest = Players.Instance.list[0];
                float closestDistance = 1000f;

                foreach (Transform player in Players.Instance.list)
                {
                    float distance = Vector2.Distance(enemyObject.transform.position, player.position);

                    if (distance < closestDistance && player.gameObject.activeSelf)
                    {
                        closestDistance = distance;
                        closest = player;
                    }
                }

                _target.SetTarget(target: closest);
            }

            SpawnCD = Time.time + SpawnRate;
        }
    }
}
