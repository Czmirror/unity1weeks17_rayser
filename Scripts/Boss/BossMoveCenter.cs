using UnityEngine;

namespace RAYSER.Scripts.Boss
{
    

    public class BossMoveCenter : MonoBehaviour, IMovable
    {
        [SerializeField]
        private float speed;
        
        public void Move()
        {
            if (transform.position.z < 0)
            {
                return;
            }
            
            transform.position += transform.forward * speed;
        }

        private void Start()
        {
            var targetPosition = GameObject.Find("Center");
            transform.LookAt(targetPosition.transform.position);
        }

        private void Update()
        {
            Move();
        }
    }
}

