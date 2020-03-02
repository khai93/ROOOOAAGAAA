using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
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
        var isHealthUnderMax = health.GetCurrentHealth() <= health.MaxHealth * (ActivateAtHealthPercentage / 100);
        if (isHealthUnderMax)
        {
            SwitchPhase();
            Destroy(gameObject);
        }
    }

    private void SwitchPhase()
    {
        GameObject newEntity = Instantiate(NextPhasePrefab);
        newEntity.transform.position = transform.position;

        if (PhaseTransitionEffect != null)
        {
            GameObject effect = Instantiate(PhaseTransitionEffect);
            effect.transform.position = transform.position;
        }
    }
}
