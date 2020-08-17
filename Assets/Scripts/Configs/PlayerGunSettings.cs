using Game.Bullet;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "PlayerGunSettings", menuName = "Configs/Gun/PlayerGunSettings", order = 0)]
    public class PlayerGunSettings : ScriptableObject
    {
        [SerializeField] private BulletBehavior bulletPrefab;
        [SerializeField] private float reloadTime = 1f;

        public BulletBehavior BulletPrefab => bulletPrefab;
        public float ReloadTime => reloadTime;
    }
}