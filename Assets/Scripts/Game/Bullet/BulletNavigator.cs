using System.Collections.Generic;
using Game.Enemy;
using UnityEngine;

namespace Game.Bullet
{
    public class BulletNavigator : MonoBehaviour
    {
        [SerializeField] private List<EnemyBehavior> enemies;

        private void Start()
        {
            foreach (var enemy in enemies)
            {
                enemy.OnDestroy += OnEnemyDestroy;
            }
        }

        private void OnEnemyDestroy(EnemyBehavior enemy)
        {
            enemies.Remove(enemy);
        }

        public Transform GetClosestEnemyTr(Vector3 position)
        {
            if (enemies.Count == 0)
            {
                return null;
            }

            var result = enemies[0].transform;
            var closest = Vector3.Distance(position, result.position);
            for (int i = 1; i < enemies.Count; i++)
            {
                var enemy = enemies[i];
                var distance = Vector3.Distance(position, enemy.transform.position);
                if (distance < closest)
                {
                    result = enemy.transform;
                    closest = distance;
                }
            }

            return result;
        }
    }
}