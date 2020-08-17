using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "EnemyKillEffectSettings", menuName = "Configs/Enemy/EnemyKillEffectSettings", order = 0)]
    public class EnemyKillEffectSettings : ScriptableObject
    {
        [SerializeField] private GameObject particlesPrefab;
        [SerializeField] private int particlesCount = 5;
        [SerializeField] private float spawnRadius = 2;

        public GameObject ParticlesPrefab => particlesPrefab;
        public int ParticlesCount => particlesCount;
        public float SpawnRadius => spawnRadius;
    }
}