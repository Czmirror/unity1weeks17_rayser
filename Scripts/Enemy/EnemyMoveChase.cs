using System.Collections;
using System.Collections.Generic;
using RAYSER.Scripts;
using UnityEngine;

namespace RAYSER.Scripts.Enemy
{
    public class EnemyMoveChase : MonoBehaviour,IMovable
    {
        [SerializeField] private GameObject target;
        [SerializeField] private float speed;
    
        void Start()
        {
            target = GameObject.Find("Player");
        
        }

        void Update()
        {
            Move();
        }

        public void Move()
        {
            transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (target.transform.position - transform.position), 0.3f);
            transform.position += transform.forward * speed;
        }
    }
}

