using System.Collections;
using UniRx;
using UnityEngine;

namespace RAYSER.Scripts.Player
{
    public class PlayerShield : MonoBehaviour, IDamageableToEnemy
    {
        [SerializeField] private GameObject damageEffect;

        [SerializeField] private GameObject explosion;

        // 現在のシールド
        public IntReactiveProperty shield = new IntReactiveProperty(6);

        // シールド有効状態
        public ReactiveProperty<bool> shieldActivate = new ReactiveProperty<bool>(false);

        private Coroutine shieldCoroutine;

        // シールド有効時間
        [SerializeField] private float shieldTime;

        /*
         * ダメージ処理
         */
        public void AddDamage(float damage)
        {
            if (shieldActivate.Value) return;

            shield.Value--;
            var _damage_explosion = Instantiate(damageEffect, transform.position, transform.rotation);

            if (shield.Value > 0)
            {
                shieldActivate.Value = true;
                StartCoroutine("ShieldTimeReduce");
            }
            else
            {
                shieldActivate.Value = false;
                var _explosion = Instantiate(explosion, transform.position, transform.rotation);
                gameObject.SetActive(false);
            }
        }

        /*
         * 接触処理
         */
        private void OnTriggerEnter(Collider other)
        {
            var damagetarget = other.transform.GetComponent<IDamageableToPlayer>();
            if (damagetarget != null)
            {
                var damage = 1.0f;
                other.transform.GetComponent<IDamagable>().AddDamage(damage);
            }
        }

        /*
         * シールド有効時間減少処理
         */
        private IEnumerator ShieldTimeReduce()
        {
            shieldActivate.Value = true;

            yield return new WaitForSeconds(shieldTime);

            shieldActivate.Value = false;
        }
    }
}
