using UnityEngine;

[RequireComponent(typeof(ITarget<Transform>))]
public class TargetClosestPlayer : MonoBehaviour
{
    private ITarget<Transform> _target;

    private void Awake()
    {
        _target = GetComponent<ITarget<Transform>>();
    }

    private void Update()
    {
        var closest = FindClosest();

        if (closest != null)
        {
            _target.SetTarget(target: closest);
        }
    }

    private Transform FindClosest()
    {
        Transform closest = null;
        float closestDistance = Mathf.Infinity;

        foreach (Transform player in PlayersContainer.Instance.Players)
        {
            float distance = Vector2.Distance(transform.position, player.position);

            if (distance < closestDistance && player.gameObject.activeSelf)
            {
                closestDistance = distance;
                closest = player;
            }
        }

        return closest;
    }
}
