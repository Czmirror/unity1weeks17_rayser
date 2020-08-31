using System;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RAYSER.Scripts.Enemy
{
    public class SpawnEnemy : MonoBehaviour
    {
        // 表示する敵プレハブ
        [SerializeField] private GameObject[] enemies;

        private readonly IntReactiveProperty enemyCount = new IntReactiveProperty(0);
        private GameObject player;

        // 一度に表示する敵の数
        [SerializeField] private int spawnNum;

        // 表示する敵の出現位置、自機を基準とした相対で指定
        [SerializeField] private Vector3[] spawnPositions;

        // 敵を出現させる処理を実行する敵の残り数
        [SerializeField] private int spawnRestNum;

        private void Start()
        {
            player = GameObject.Find("Player");

            Observable.Interval(TimeSpan.FromSeconds(5)).Subscribe(_ => { SpawnCheck(); }).AddTo(this);
        }

        private void SpawnCheck()
        {
            if (enemyCount.Value >= spawnRestNum) return;

            for (var i = 0; i < spawnNum; i++) Spawn();
        }

        private void Spawn()
        {
            var enemyIndex = Random.Range(0, enemies.Length);
            var enemy = enemies[enemyIndex];

            // 座標指定
            var positionIndex = Random.Range(0, spawnPositions.Length);
            var _pos = spawnPositions[positionIndex];
//            var _y = Random.Range(-1, 1); // Y軸にランダム座標追加
//            _pos.y = _y;

            var enemyPosition = player.transform.position + _pos;
            var spawnRotate = new Quaternion(0, 0, 0, 0);
            var _enemy = Instantiate(enemy, enemyPosition, spawnRotate);
            enemyCount.Value++;
        }

        // 敵の個数を減少させる
        public void EnemyCountDecrease()
        {
            enemyCount.Value--;
        }
    }
}
