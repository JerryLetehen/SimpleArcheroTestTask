using Configs;
using UnityEngine;

namespace Game.Enemy
{
    public class EnemyKillEffect : MonoBehaviour
    {
        [SerializeField] private EnemyKillEffectSettings settings;
        [SerializeField] private EnemyBehavior enemy;

        private Vector3 killPos;

        private void Start()
        {
            enemy.OnDestroy += OnEnemyDestroy;
        }

        private void OnEnemyDestroy(EnemyBehavior enemy)
        {
            killPos = transform.position;
            transform.SetParent(null);
            SpawnParticles();
            Destroy(gameObject);
        }

        private void SpawnParticles()
        {
            for (int i = 0; i < settings.ParticlesCount; i++)
            {
                Instantiate(settings.ParticlesPrefab, GetRandomNearPos(), Quaternion.identity);
            }
        }

        private Vector3 GetRandomNearPos()
        {
            return new Vector3(Random.Range(-settings.SpawnRadius, settings.SpawnRadius) + killPos.x, killPos.y, Random.Range(-settings.SpawnRadius, settings.SpawnRadius) + killPos.z);
        }
    }
}