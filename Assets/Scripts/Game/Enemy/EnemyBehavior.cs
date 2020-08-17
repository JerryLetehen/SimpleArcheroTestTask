using System;
using Configs;
using Game.Bullet;
using UnityEngine;

namespace Game.Enemy
{
    public class EnemyBehavior : MonoBehaviour
    {
        public event Action<EnemyBehavior> OnDestroy;
        
        [SerializeField] private EnemyBehaviorSettings settings;

        private Health health;

        private void Start()
        {
            health = new Health(settings.StartHealth);
            health.OnHealthEnded += OnOnHealthEnded;
        }

        private void OnOnHealthEnded()
        {
            OnDestroy?.Invoke(this);
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            var bullet = other.GetComponent<BulletBehavior>();
            if (bullet != null)
            {
                bullet.StopFlight();
                health.Reduce();
            }
        }
    }
}