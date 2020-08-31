using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;


namespace RAYSER.Scripts.Enemy
{
    public class EnemyMoveWhileStopping : MonoBehaviour
    {
        
        [SerializeField] private GameObject target;
        [SerializeField] private float speed;
        [SerializeField] private float duration;
        [SerializeField] private float span;
        
        // Start is called before the first frame update
        private async void Start()
        {
            target = GameObject.Find("Player");

            var token = this.GetCancellationTokenOnDestroy();
//            WaitForCanceledAsync(token).Forget();
            
            await Move ();
        }
        
//        private async UniTaskVoid WaitForCanceledAsync(CancellationToken token)
//        {
//            await token.WaitUntilCanceled();
//            Debug.Log("Canceled!");
//        }
        
        private async UniTask Move ()
        {
            while (true)
            {
                var targetPosition = target.transform.position;
//                transform.LookAt(targetPosition);
                transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (target.transform.position - transform.position), 0.3f);
                transform.position += transform.forward * speed;
                
                Debug.Log("wait!");
                await UniTask.Delay(1000 * (int)duration);

            }
            
            
//            
//            var startTime = Time.time;
//
//            // 待機時間（UniTask.Delay に変換。 引数にはミリ秒の int を指定する）
//            var span = UniTask.Delay((int) (this.span * 1000));
//            
//            while ( Time.time - startTime < duration )
//            {
//                Debug.Log("Unitask Move action!");
//                var targetPosition = target.transform.position;
//                transform.LookAt(targetPosition);
//                //transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (target.transform.position - transform.position), 0.3f);
//                transform.position += transform.forward * speed;
//                await span;       // 一歩ごとに待機
//            }
        }
    }
}

