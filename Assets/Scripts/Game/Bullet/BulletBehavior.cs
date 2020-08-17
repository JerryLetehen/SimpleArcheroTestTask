using System.Threading;
using System.Threading.Tasks;
using Configs;
using UnityEngine;

namespace Game.Bullet
{
    public class BulletBehavior : MonoBehaviour
    {
        [SerializeField] protected BulletBehaviorSettings settings;

        protected bool IsAbleToFlight
        {
            get
            {
                if (flightTokenSource?.IsCancellationRequested == false)
                {
                    if (target == null)
                    {
                        StopFlight();
                        return false;
                    }

                    return true;
                }

                return false;
            }
        }

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

        protected virtual async void Flight()
        {
            while (IsAbleToFlight)
            {
                TranslateToTarget();
                await Task.Yield();
            }
        }

        private void TranslateToTarget()
        {
            transform.Translate((target.position - transform.position).normalized * (settings.Speed * Time.deltaTime));
        }

        private void OnDestroy()
        {
            StopFlight();
        }

        public void StopFlight()
        {
            flightTokenSource?.Cancel();
            Destroy(gameObject);
        }
    }
}