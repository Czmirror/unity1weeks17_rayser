using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RAYSER.Scripts.Enemy
{
    public class EnemyMoveApproach : MonoBehaviour,IMovable
    {
        [SerializeField] private GameObject target;
        [SerializeField] private float speed;
        [SerializeField] private float stopDistance;
        
        // Start is called before the first frame update
        void Start()
        {
            target = GameObject.Find("Player");
        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }
        
        public void Move()
        {
            if (!target)
            {
                return;
            }
            
            var targetPosition = target.transform.position;
            
            transform.LookAt(targetPosition);

            var distance = Vector3.Distance(transform.position, targetPosition);

            if ( distance > stopDistance)
            {
                transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (target.transform.position - transform.position), 0.3f);
                transform.position += transform.forward * speed;
            }
        }
    }

}

