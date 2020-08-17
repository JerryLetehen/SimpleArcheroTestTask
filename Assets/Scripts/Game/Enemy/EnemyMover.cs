using Configs;
using UnityEngine;

namespace Game.Enemy
{
    public class EnemyMover : MonoBehaviour
    {
        [SerializeField] private EnemyMoverSettings settings;
        [SerializeField] private Transform[] points;
        [SerializeField] private Rigidbody rb;

        private int pointIndex;
        private Transform point;

        private void Start()
        {
            point = points[pointIndex];
        }

        private void AssignPoint(int index)
        {
            point = points[index % points.Length];
        }

        private void Update()
        {
            if (Vector3.Distance(transform.position, point.position) < 0.1f)
            {
                AssignPoint(pointIndex++);
            }

            rb.velocity = (point.position - transform.position).normalized * settings.Speed;
        }
    }
}