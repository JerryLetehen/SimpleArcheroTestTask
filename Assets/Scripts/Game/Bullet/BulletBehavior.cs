using System.Threading;
using System.Threading.Tasks;
using Configs;
using UnityEngine;

namespace Game.Bullet
{
    public class BulletBehavior : MonoBehaviour
    {
        [SerializeField] private BulletBehaviorSettings settings;

        private CancellationTokenSource flightTokenSource;
        private Transform target;

        public void SetTarget(Transform tr)
        {
            target = tr;
            StartFlight();
        }

        private void StartFlight()
        {
            transform.SetParent(null);
            flightTokenSource = new CancellationTokenSource();
            Flight();
        }

        private async void Flight()
        {
            while (flightTokenSource.IsCancellationRequested == false)
            {
                transform.Translate((target.position - transform.position).normalized * (settings.Speed * Time.deltaTime));
                await Task.Yield();
            }
        }

        private void OnDestroy()
        {
            flightTokenSource?.Cancel();
        }
    }
}