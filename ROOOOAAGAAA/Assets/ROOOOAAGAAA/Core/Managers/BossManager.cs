using System.Linq;
using UnityEngine;
using ROOOOAAGAAA.Core;

public class BossManager : MonoBehaviour
{
    [SerializeField]
    private float TransitionTime;

    public static BossManager instance;

    public static GameObject currentBossObject;

    private GameObject[] _bossPrefabs;
    private int _currentBoss;

    private float _NextTransition;
    private bool _inTransition;
   
    private void Awake()
    {
        if (instance != null)
            return;

        instance = this;
    }

    private void Start()
    {
        // Load all Bosses
        _bossPrefabs = Resources.LoadAll("Bosses", typeof(GameObject)).Cast<GameObject>().ToArray();

        _currentBoss = GameManager.Boss;

        // Start up transition for the first boss
        _NextTransition = Time.time + TransitionTime;
        _inTransition = true;
    }

    private void Update()
    {
        // Check if next transition is initialized
        if (_inTransition && Time.time >= _NextTransition)
        {
            currentBossObject = Instantiate(_bossPrefabs[GameManager.Boss]);
            _inTransition = false;
        }

        // It's really weird to see a comparison of bosses.
        // Does it mean that you need to switch to a new boss?
        // Could be calrified with something such as BossIndex.
        if (GameManager.Boss > _currentBoss)
        {
            _currentBoss = GameManager.Boss;

            // Dying does not actually remove the object from game, just makes it inactive
            Destroy(currentBossObject);

            _NextTransition = Time.time + TransitionTime;
            _inTransition = true;
        }

    }
}
