using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "BulletBehaviorSettings", menuName = "Configs/Bullet/BulletBehaviorSettings", order = 0)]
    public class BulletBehaviorSettings : ScriptableObject
    {
        [SerializeField] private float speed;

        public float Speed => speed;
    }
}