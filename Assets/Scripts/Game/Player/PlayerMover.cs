using Configs;
using UnityEngine;

namespace Game.Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private PlayerMoverSettings settings;
        [SerializeField] private Rigidbody rb;

        private void Update()
        {
            if (Input.anyKey == false)
            {
                return;
            }
            
            var verticalAxis = Input.GetAxis("Vertical");
            var horizontalAxis = Input.GetAxis("Horizontal");
            rb.velocity = new Vector3(horizontalAxis * settings.Speed, 0f, verticalAxis * settings.Speed);
        }
    }
}