using MilkShake;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "CameraShakeSettings", menuName = "Configs/Camera/CameraShakeSettings", order = 0)]
    public class CameraShakeSettings : ScriptableObject
    {
        [SerializeField] private ShakeParameters parameters;

        public IShakeParameters ShakeParameters => parameters;
    }
}