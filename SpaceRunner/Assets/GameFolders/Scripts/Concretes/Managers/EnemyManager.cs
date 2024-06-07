using System.Collections.Generic;
using SpaceRunner.Abstracts.Utilities;
using SpaceRunner.Controllers;
using SpaceRunner.Enums;
using UnityEngine;
using UnityEngine.Serialization;

namespace SpaceRunner.Managers
{
    public class EnemyManager : SingletonMonoBehaviourObject<EnemyManager>
    {

        #region Self Variables

        #region Serialized Variables

        [SerializeField] float addDelayTime = 50f;
        [SerializeField] private EnemyController[] enemyPrefabs;

        #endregion

        #region Private Variables
        
        private Dictionary<EnemyEnum, Queue<EnemyController>>  _enemies = new Dictionary<EnemyEnum, Queue<EnemyController>>();
        private float _moveSpeed;
        
        #endregion

        #region Public Variables

        public float AddDelayTime => addDelayTime;
        public int Count => enemyPrefabs.Length;

        #endregion

        #endregion
        
        private void Awake()
        {
            SingletonThisObject(this);
        }

        private void Start()
        {
            InitializePool();
        }

        private void InitializePool()
        {
            for (int i = 0; i < enemyPrefabs.Length; i++)
            {
                Queue<EnemyController> enemyControllers = new Queue<EnemyController>();
                for (int j = 0; j < 10; j++)
                {
                    EnemyController newEnemy = Instantiate(enemyPrefabs[i]);
                    newEnemy.gameObject.SetActive(false);
                    newEnemy.transform.parent = this.transform;
                    enemyControllers.Enqueue(newEnemy);
                }  
                _enemies.Add((EnemyEnum)i, enemyControllers);
            }
        }

        public void SetPool(EnemyController enemyController)
        {
            enemyController.gameObject.SetActive(false);
            enemyController.transform.parent = this.transform;

            Queue<EnemyController> enemyControllers = _enemies[enemyController.EnemyType];
            enemyControllers.Enqueue(enemyController);
        }

        public EnemyController GetPool(EnemyEnum enemyType)
        {
            Queue<EnemyController> enemyControllers = _enemies[enemyType];

            if (enemyControllers.Count == 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    EnemyController newEnemy = Instantiate(enemyPrefabs[(int)enemyType]);
                    newEnemy.gameObject.SetActive(false);
                    enemyControllers.Enqueue(newEnemy);
                }
            }
            
            EnemyController enemyController = enemyControllers.Dequeue();
            enemyController.SetMoveSpeed(_moveSpeed);
            
            return enemyController;
        }

        public void SetMoveSpeed(float moveSpeed)
        {
            _moveSpeed = moveSpeed;
        }
        
        public void SetAddDelayTime(float addDelayTime)
        {
            addDelayTime = addDelayTime;
        }
    }
}
