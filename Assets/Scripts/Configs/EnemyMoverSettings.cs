using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "EnemyMoverSettings", menuName = "Configs/Enemy/EnemyMoverSettings", order = 0)]
    public class EnemyMoverSettings : ScriptableObject
    {
        [SerializeField] private float speed;

        public float Speed => speed;
    }
}