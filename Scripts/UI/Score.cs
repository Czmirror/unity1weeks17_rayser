using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace RAYSER.Scripts.UI
{
    public class Score : MonoBehaviour
    {
        public ReactiveProperty<int> currentScore = new ReactiveProperty<int>(0);

        public int CurrentScore
        {
            get { return currentScore.Value; }
        }

        public void UpdateScore(int score)
        {
            currentScore.Value += score;
        }
    }
}