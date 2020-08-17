using Configs;
using Game.Enemy;
using MilkShake;
using UnityEngine;

namespace Game
{
    public class LevelBehavior : MonoBehaviour
    {
        [SerializeField] private EnemyBehavior[] enemies;
        [SerializeField] private CameraShakeSettings cameraShakeSettings;
        [SerializeField] private Shaker camShaker;

        private void Start()
        {
            foreach (var enemy in enemies)
            {
                enemy.OnDestroy += OnEnemyDestroy;
            }
        }

        private void OnEnemyDestroy(EnemyBehavior enemy)
        {
            camShaker.Shake(cameraShakeSettings.ShakeParameters);
        }
    }
}