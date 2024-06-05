using UnityEngine;

namespace SpaceRunner.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        [SerializeField] private EnemyController enemyPrefab;
        [SerializeField] [Range(0.1f, 5f)] private float min = 0.1f;
        [SerializeField] [Range(6f, 15f)] float max = 15f;
        
        private float maxSpawnTime;
        private float _currentSpawnTime;

        private void OnEnable()
        {
            GetRandomMaxTime();
        }

        private void Update()
        {
            _currentSpawnTime += Time.deltaTime;
            if (_currentSpawnTime > maxSpawnTime)
            {
                Spawn();
            }
        }

        private void Spawn()
        {
            Instantiate(enemyPrefab, transform.position, transform.rotation, transform);
            _currentSpawnTime = 0;
            GetRandomMaxTime();
        }
        
        private void GetRandomMaxTime()
        {
            maxSpawnTime = Random.Range(min, max);
        }
    }
}
