using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "PlayerMoverSettings", menuName = "Configs/Player/PlayerMoverSettings", order = 0)]
    public class PlayerMoverSettings : ScriptableObject
    {
        [SerializeField] private float speed;

        public float Speed => speed;
    }
}