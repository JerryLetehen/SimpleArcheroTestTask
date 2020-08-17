using Configs;
using Game.Bullet;
using UnityEngine;

namespace Game.Player
{
    public class PlayerGun : MonoBehaviour
    {
        [SerializeField] private PlayerGunSettings settings;
        [SerializeField] private Transform bulletHolder;
        [SerializeField] private BulletNavigator bulletNavigator;

        private bool IsReadyToFire => Time.time - lastFireTime >= settings.ReloadTime;

        private bool isLocked = true;
        private float lastFireTime;

        public void StartShooting()
        {
            isLocked = false;
        }

        public void StopShooting()
        {
            isLocked = true;
        }

        private void Update()
        {
            if (isLocked == false && IsReadyToFire)
            {
                Fire();
            }
        }

        private void Fire()
        {
            var target = bulletNavigator.GetClosestEnemyTr(transform.position);
            if (target == null)
            {
                return;
            }

            lastFireTime = Time.time;
            var bullet = Instantiate(settings.BulletPrefab, bulletHolder);
            bullet.SetTarget(target);
        }
    }
}