using RAYSER.Scripts.Score;
using UnityEngine;

namespace RAYSER.Scripts.Boss
{
    public class BossParts : MonoBehaviour, IDamageableToPlayer, IScore
    {
        [SerializeField] private GameObject damageEffect;

        [SerializeField] private GameObject explosion;
        [SerializeField] private UI.Score scoreUI;
        [SerializeField] private int scoreValue;
        [SerializeField] private float shield;

        public void AddDamage(float damage)
        {
            shield -= damage;

            if (shield <= 0)
            {
                var _explosion = Instantiate(explosion, transform.position, Quaternion.identity);
                AddScore();
                Destroy(gameObject);
            }
            else if (shield > 0)
            {
                var _explosion = Instantiate(damageEffect, transform.position, Quaternion.identity);
            }
        }

        public void AddScore()
        {
            scoreUI.UpdateScore(scoreValue);
        }

        private void Start()
        {
            scoreUI = GameObject.Find("Canvas/ScoreUI").GetComponent<UI.Score>();
        }


        private void OnTriggerStay(Collider other)
        {
            var damagetarget = other.transform.GetComponent<IDamageableToEnemy>();
            if (damagetarget != null)
            {
                var damage = 1.0f;
                other.transform.GetComponent<IDamagable>().AddDamage(damage);
            }
        }
    }
}
