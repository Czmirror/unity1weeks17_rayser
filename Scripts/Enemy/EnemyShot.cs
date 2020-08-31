using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RAYSER.Scripts.Enemy
{
    public class EnemyShot : MonoBehaviour, IAttackable
    {
        [SerializeField] private GameObject shot;

        [SerializeField] private float shotInterval = 1.5f;
        [SerializeField] private float shotIntervalCurrent = 0.0f;

        void Start()
        {
            StartCoroutine("AttackInterval");
        }

        /*
         * 攻撃処理
         */
        public void Attack()
        {
            GameObject _shot = Instantiate(shot, transform.position, transform.rotation);
        }


        /*
         * 攻撃インターバル
         */
        public IEnumerator AttackInterval()
        {
            while (true)
            {
                yield return new WaitForSeconds(shotInterval);
                Attack();
            }
        }
    }
}
