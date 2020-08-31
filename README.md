# unity1weeks17_rayser
RAYSER(V2)の公開ソースです（Scriptのみ）

一週間ゲームジャム「ふえる」で実装したRAYSER(V2)のスクリプトです。

Scripts/
├── Asteroid 隕石関連のスクリプト
│   ├── Asteroid.cs
│   ├── Asteroid.cs.meta
│   ├── AsteroidMove.cs
│   └── AsteroidMove.cs.meta
├── Asteroid.meta
├── Boss ボスキャラのスクリプト
│   ├── Boss.cs
│   ├── Boss.cs.meta
│   ├── BossMoveCenter.cs
│   ├── BossMoveCenter.cs.meta
│   ├── BossParts.cs
│   ├── BossParts.cs.meta
│   ├── SpawnBoss.cs
│   └── SpawnBoss.cs.meta
├── Boss.meta
├── Bullet レーザーと敵の弾のスクリプト
│   ├── EnemyBeam.cs
│   ├── EnemyBeam.cs.meta
│   ├── Laser.cs
│   └── Laser.cs.meta
├── Bullet.meta
├── Burst.cs 隕石の自爆処理用
├── Burst.cs.meta
├── ButtonSceneMove.cs ボタン押下のシーン遷移
├── ButtonSceneMove.cs.meta
├── Enemy 敵機のスクリプト
│   ├── Enemy.cs
│   ├── Enemy.cs.meta
│   ├── EnemyMoveApproach.cs
│   ├── EnemyMoveApproach.cs.meta
│   ├── EnemyMoveChase.cs
│   ├── EnemyMoveChase.cs.meta
│   ├── EnemyMoveWhileStopping.cs
│   ├── EnemyMoveWhileStopping.cs.meta
│   ├── EnemyShot.cs
│   ├── EnemyShot.cs.meta
│   ├── SpawnEnemy.cs
│   └── SpawnEnemy.cs.meta
├── Enemy.meta
├── Explosion.cs 爆発処理のスクリプト
├── Explosion.cs.meta
├── IAttackable.cs 攻撃用インターフェース
├── IAttackable.cs.meta
├── IDamageable.cs ダメージ処理用インターフェース
├── IDamageable.cs.meta
├── IDamageableToEnemy.cs ダメージ処理（敵機）用インターフェース
├── IDamageableToEnemy.cs.meta 
├── IDamageableToPlayer.cs ダメージ処理（自機）用インターフェース
├── IDamageableToPlayer.cs.meta
├── IMovable.cs 移動用インターフェース
├── IMovable.cs.meta
├── IScore.cs スコア用インターフェース
├── IScore.cs.meta
├── LaserTarget.cs レーザーロックオン用スクリプト
├── LaserTarget.cs.meta
├── LaserTest.cs 動作確認用（未使用）
├── LaserTest.cs.meta
├── Player 自機のスクリプト
│   ├── PlayerMove.cs
│   ├── PlayerMove.cs.meta
│   ├── PlayerShield.cs
│   ├── PlayerShield.cs.meta
│   ├── PlayerShieldEffect.cs
│   ├── PlayerShieldEffect.cs.meta
│   ├── PlayerShot.cs
│   └── PlayerShot.cs.meta
├── Player.meta
├── Skybox 背景用スクリプト
│   ├── RotateSkyBox.cs
│   └── RotateSkyBox.cs.meta
├── Skybox.meta
├── UI UI関連のスクリプト
│   ├── PresenterGameOver.cs
│   ├── PresenterGameOver.cs.meta
│   ├── PresenterScore.cs
│   ├── PresenterScore.cs.meta
│   ├── PresenterShield.cs
│   ├── PresenterShield.cs.meta
│   ├── RankingButton.cs
│   ├── RankingButton.cs.meta
│   ├── Score.cs
│   ├── Score.cs.meta
│   ├── TitleLogoLine.cs
│   ├── TitleLogoLine.cs.meta
│   ├── TwitterButton.cs
│   └── TwitterButton.cs.meta
└── UI.meta

