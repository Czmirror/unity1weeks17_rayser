using System;
using System.Collections;
using UniRx;
using UnityEngine;

namespace RAYSER.Scripts.Boss
{
    public class SpawnBoss : MonoBehaviour
    {
        [SerializeField] private int spawnTime;
        [SerializeField] private GameObject boss;

        private IntReactiveProperty bossCount = new IntReactiveProperty(0);
        private void Start()
        {
            bossCount.Subscribe(_ => Spawn());
        }
        
        private void Spawn(){
            // ボスがいる場合は処理終了
            if (bossCount.Value >= 1)
            {
                StopCoroutine("SpawnWaiting");
                return;
            }
            
            // 待機処理
            StartCoroutine("SpawnWaiting");
        }

        // ボスの待機処理のコルーチン
        private IEnumerator SpawnWaiting()
        {
            yield return new WaitForSeconds(spawnTime);
            
            // スポーン処理
            var spawnRotate = new Quaternion(0, 0, 0, 0);
            var bossPosition = new Vector3(0,0, 50);
            var _boss = Instantiate(boss, bossPosition, spawnRotate);
            bossCount.Value++;
        }

        // ボスの個数を減少させる
        public void BossCountDecrease()
        {
            bossCount.Value--;
        }
    }
}
