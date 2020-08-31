using RAYSER.Scripts;
using RAYSER.Scripts.Enemy;
using RAYSER.Scripts.Score;
using UnityEngine;

namespace RAYSER.Scripts.Asteroid
{
    public class Asteroid : MonoBehaviour, IDamageableToPlayer, IDamageableToEnemy
    {
        [SerializeField] private float shield;

        [SerializeField] private GameObject explosion;
        [SerializeField] private GameObject damageEffect;
        [SerializeField] private SpawnEnemy spawnAsteroid;

        private void Start()
        {
            spawnAsteroid = GameObject.Find("SpawnAsteroid").GetComponent<SpawnEnemy>();
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
                var _explosion = Instantiate(this.explosion, transform.position, transform.rotation) as GameObject;
                spawnAsteroid.EnemyCountDecrease();
                Destroy(gameObject);
            }
            else if (shield > 0)
            {
                var _explosion = Instantiate(this.damageEffect, transform.position, transform.rotation) as GameObject;
            }
        }

    }
}
