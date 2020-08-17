using System;
using Configs;
using UnityEngine;

namespace Game.Player
{
    public class PlayerMover : MonoBehaviour
    {
        public event Action<bool> OnPlayerMovingStateChanged;
        
        [SerializeField] private PlayerMoverSettings settings;
        [SerializeField] private Rigidbody rb;

        private bool IsMoving
        {
            set
            {
                if (isMoving != value)
                {
                    OnPlayerMovingStateChanged?.Invoke(value);
                }

                isMoving = value;
            }
        }

        private bool isMoving;

        private const float FloatTolerance = 0.01f;
        
        private void Update()
        {
            if (Input.anyKey == false)
            {
                IsMoving = false;
                return;
            }

            var verticalAxis = Input.GetAxis("Vertical");
            var horizontalAxis = Input.GetAxis("Horizontal");

            var velocity = Vector3.zero;
            
            if (Math.Abs(verticalAxis) < FloatTolerance && Math.Abs(horizontalAxis) < FloatTolerance)
            {
                IsMoving = false;
            }
            else
            {
                IsMoving = true;
                velocity.x = horizontalAxis * settings.Speed;
                velocity.z = verticalAxis * settings.Speed;
            }
            
            rb.velocity = velocity;
        }
    }
}