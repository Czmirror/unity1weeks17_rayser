using RAYSER.Scripts;
using RAYSER.Scripts.Score;
using RAYSER.Scripts.UI;
using UnityEngine;

namespace RAYSER.Scripts.Boss
{
    public class Boss : MonoBehaviour, IDamageableToPlayer, IScore
    {
        [SerializeField] private float shield;

        [SerializeField] private GameObject explosion;
        [SerializeField] private GameObject damageEffect;
        [SerializeField] private UI.Score scoreUI;
        [SerializeField] private int scoreValue;
        [SerializeField] private SpawnBoss spawnBoss;

        private void Start()
        {
            scoreUI = GameObject.Find("Canvas/ScoreUI").GetComponent<UI.Score>();
            spawnBoss = GameObject.Find("SpawnBoss").GetComponent<SpawnBoss>();
        }


        private void OnTriggerStay(Collider other)
        {
            var damagetarget = other.transform.GetComponent<IDamageableToEnemy>();
            if (damagetarget != null)
            {
                float damage = 1.0f;
                other.transform.GetComponent<IDamagable>().AddDamage(damage);
            }
        }

        public void AddDamage(float damage)
        {
            shield -= damage;

            if (shield <= 0)
            {
                var _explosion = Instantiate(this.explosion, transform.position, Quaternion.identity) as GameObject;
                AddScore();
                spawnBoss.BossCountDecrease();               
                Destroy(transform.root.gameObject);
            }
            else if (shield > 0)
            {
                var _explosion = Instantiate(this.damageEffect, transform.position, Quaternion.identity) as GameObject;
            }
        }

        public void AddScore()
        {
            scoreUI.UpdateScore(scoreValue);
        }
    }
}
