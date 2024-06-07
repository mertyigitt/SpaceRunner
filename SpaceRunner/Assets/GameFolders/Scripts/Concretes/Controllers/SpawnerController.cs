using SpaceRunner.Enums;
using SpaceRunner.Managers;
using UnityEngine;

namespace SpaceRunner.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] [Range(0.1f, 5f)] private float min = 0.1f;
        [SerializeField] [Range(6f, 15f)] float max = 15f;

        #endregion

        #region Private Variables

        private float maxSpawnTime;
        private float _currentSpawnTime;
        private int _index = 0;
        private float _maxAddEnemyTime;

        #endregion

        #region Public Variables

        public bool CanIncrease => _index < EnemyManager.Instance.Count;

        #endregion

        #endregion
        
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

            if (!CanIncrease) return;

            if (_maxAddEnemyTime < Time.time)
            {
                _maxAddEnemyTime = Time.time + EnemyManager.Instance.AddDelayTime;
                IncreaseIndex();
            }
        }

        private void Spawn()
        {
            EnemyController newEnemy = EnemyManager.Instance.GetPool((EnemyEnum)Random.Range(0,_index));
            newEnemy.transform.parent = this.transform;
            newEnemy.transform.position = this.transform.position;
            newEnemy.gameObject.SetActive(true);
            
            _currentSpawnTime = 0;
            GetRandomMaxTime();
        }
        
        private void GetRandomMaxTime()
        {
            maxSpawnTime = Random.Range(min, max);
        }
        
        private void IncreaseIndex()
        {
            if (CanIncrease)
            {
                _index++;
            }
        }
    }
}
