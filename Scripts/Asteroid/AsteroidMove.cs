using UnityEngine;

namespace RAYSER.Scripts.Asteroid
{
    public class AsteroidMove : MonoBehaviour, IMovable
    {
        [SerializeField] private float speed;
        [SerializeField] private GameObject target;

        public void Move()
        {
            if (!target) return;

            transform.position += transform.forward * speed;
        }

        private void Start()
        {
            target = GameObject.Find("Player");
            if (target)
            {
                var targetPosition = target.transform.position;
                transform.LookAt(targetPosition);
            }
            
        }

        private void Update()
        {
            Move();
        }
    }
}
