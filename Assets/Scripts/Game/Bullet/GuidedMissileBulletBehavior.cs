using System.Threading.Tasks;
using Configs;
using UnityEngine;

namespace Game.Bullet
{
    public class GuidedMissileBulletBehavior : BulletBehavior
    {
        [SerializeField] private GuidedMissileBulletBehaviorSettings guidedMissileSettings;
        [SerializeField] private Rigidbody rb;

        protected override async void Flight()
        {
            await LunchUp();
            TurnPhysicsOff();
            base.Flight();
        }

        private async Task LunchUp()
        {
            var g = Physics.gravity.magnitude;
            var verticalSpeed = Mathf.Sqrt(2 * g * guidedMissileSettings.FlightHeight);
            rb.velocity = new Vector3(0, verticalSpeed, 0);
            var totalTime = verticalSpeed / g;
            var delayTime = (int) (totalTime * 1000);
            await Task.Delay(delayTime);
        }

        private void TurnPhysicsOff()
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }
    }
}