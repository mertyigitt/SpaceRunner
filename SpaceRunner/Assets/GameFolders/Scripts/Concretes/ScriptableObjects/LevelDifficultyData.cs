using SpaceRunner.Controllers;
using UnityEngine;

namespace SpaceRunner.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Level Difficulty", menuName = "Create Difficulty/ Create New ", order = 1)]
    public class LevelDifficultyData : ScriptableObject
    {
        [SerializeField] FloorController floorPrefab;
        [SerializeField] GameObject spawnersPrefab;
        [SerializeField] Material skyBoxMaterial;
        [SerializeField] private float moveSpeed = 7f;
        [SerializeField] float addDelayTime = 50f;

        public FloorController FloorPrefab => floorPrefab;
        public GameObject SpawnersPrefab => spawnersPrefab;
        public Material SkyBoxMaterial => skyBoxMaterial;
        public float MoveSpeed => moveSpeed;

        public float AddDelayTime => addDelayTime;
    }
}
