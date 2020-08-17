using Game.Player;
using UnityEngine;

namespace Game
{
    public class CoinBehavior : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.GetComponent<PlayerBehavior>() != null)
            {
                Destroy(gameObject);
            }
        }
    }
}