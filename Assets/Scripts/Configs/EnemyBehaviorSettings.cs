using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "EnemyBehaviorSettings", menuName = "Configs/Enemy/EnemyBehaviorSettings", order = 0)]
    public class EnemyBehaviorSettings : ScriptableObject
    {
        [SerializeField] private uint startHealth = 3;

        public uint StartHealth => startHealth;
    }
}