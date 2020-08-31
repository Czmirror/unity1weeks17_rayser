using UnityEngine;

namespace RAYSER.Scripts.Bullet
{
    public class EnemyBeam : MonoBehaviour
    {
        [SerializeField] private float damage = 1.0f;

        private void OnTriggerEnter(Collider other)
        {
            var damagetarget = other.transform.GetComponent<IDamageableToEnemy>();
            if (damagetarget != null)
            {
                other.transform.GetComponent<IDamagable>().AddDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
