using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "GuidedMissileBulletBehaviorSettings", menuName = "Configs/Bullet/GuidedMissileBulletBehaviorSettings", order = 0)]
    public class GuidedMissileBulletBehaviorSettings : ScriptableObject
    {
        [SerializeField] private float flightHeight;

        public float FlightHeight => flightHeight;
    }
}