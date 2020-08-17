using UnityEngine;

namespace Game.Player
{
    public class PlayerBehavior : MonoBehaviour
    {
        [SerializeField] private PlayerMover mover;
        [SerializeField] private PlayerGun gun;

        private void Start()
        {
            mover.OnPlayerMovingStateChanged += OnPlayerMovingStateChanged;
        }

        private void OnPlayerMovingStateChanged(bool isMoving)
        {
            if (isMoving)
            {
                gun.StopShooting();
            }
            else
            {
                gun.StartShooting();
            }
        }
    }
}