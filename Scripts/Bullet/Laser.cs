using System.Collections;
using UnityEngine;

namespace RAYSER.Scripts.Bullet
{
    public class Laser : MonoBehaviour
    {
        private Vector3 firstPosition;

        private LineRenderer lineRenderer;
        [SerializeField] private GameObject muzzleFlash;
        [SerializeField] private GameObject hitFlash;
        private GameObject player;
        public GameObject target;
        private Vector3 targetPosition;
        public float timer = 1.0f;


        public void LaserShot(GameObject shotOwner)
        {
            player = shotOwner;

            var laserTarget = GameObject.Find("Player/LaserTarget");
            target = laserTarget.GetComponent<LaserTarget>().target;

            positionSetting();
            drewLaserLine();
            raySetting();
            
            Destroy(gameObject, timer);

            StartCoroutine("FadeOut");
            Destroy(gameObject, timer);
        }

        /*
         * レーザーの座標設定
         */
        private void positionSetting()
        {
            // Target Setting
            firstPosition = player.transform.position;
            targetPosition = new Vector3(firstPosition.x, firstPosition.y, firstPosition.z);
            if (!target)
            {
                target = GameObject.Find("Player/NoTarget");
                targetPosition = target.transform.position;
            }
            else
            {
                targetPosition = target.transform.position;
            }
        }

        /*
         * レーザー描画
         */
        private void drewLaserLine()
        {
            lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.enabled = true;
            lineRenderer.SetVertexCount(2);

            // Draw Laser
            lineRenderer.SetPosition(0, firstPosition);
            lineRenderer.SetPosition(1, targetPosition);

            // MuzzleFlash
            var _muzzleFlash = Instantiate(muzzleFlash);
            _muzzleFlash.transform.position = firstPosition;
            _muzzleFlash.transform.LookAt(target.transform);
            
            // HitFlash
            var _hitFlash = Instantiate(hitFlash);
            _hitFlash.transform.position = targetPosition;
            _hitFlash.transform.LookAt(player.transform);
        }

        /*
         * Ray設定
         */
        private void raySetting()
        {
            // Ray Setting
            var heading = targetPosition - firstPosition; // Rayの目標座標
            var distance = heading.magnitude; // Rayの飛ばせる距離
            var direction = heading / distance; // Rayのベクトル
            var ray = new Ray(firstPosition, direction * distance);

            foreach (var hit in Physics.RaycastAll(ray))
            {
                var damagetarget = hit.transform.GetComponent<IDamageableToPlayer>();
                if (damagetarget != null)
                {
                    var damage = 1.0f;
                    hit.transform.GetComponent<IDamagable>().AddDamage(damage);
                }
            }

            // rayの方向ベクトルにhit迄の距離をかけ合わせて方向ベクトルを作り、発射地点の座標を足して初めてターゲットの座標が算出できる
//            var target = ray.origin + ray.direction * distance;
//            Debug.DrawLine(ray.origin, target, Color.red, 5, true);
        }

        /*
         * レーザーフェードアウト処理
         */
        public IEnumerator FadeOut()
        {
            var a = 1.0f;
            while (a > 0)
            {
                var color = new Vector4(1.0f, 1.0f, 1.0f, a);

                // SetColors(StartColot, EndColor)
                // 線の先頭と末尾で同じ色を使用しているので同じ値を指定している
                // 先端から徐々にフェードアウトしたい、みたいなケースは個別に指定が必要
                lineRenderer.SetColors(color, color);
                yield return new WaitForSeconds(0.03f);
                a -= 0.1f;
            }

            // α値が0になったら線の描画自体をやめる
            lineRenderer.enabled = false;
        }
    }
}
