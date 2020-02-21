using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPhaseAtHealthPercentage : MonoBehaviour
{
    [SerializeField]
    private GameObject PhaseTransitionEffect;

    [SerializeField]
    private GameObject NextPhasePrefab;

    [SerializeField]
    private float ActivateAtHealthPercentage;

    private Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void Update()
    {
        if (health.GetCurrentHealth() <= health.MaxHealth * (ActivateAtHealthPercentage / 100))
        {
            GameObject newEntity = Instantiate(NextPhasePrefab);
            newEntity.transform.position = transform.position;

            if (PhaseTransitionEffect != null)
            {
                GameObject effect = Instantiate(PhaseTransitionEffect);
                effect.transform.position = transform.position;
            }

            Destroy(gameObject);
        }
    }
}
