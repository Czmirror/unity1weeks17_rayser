using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RAYSER.Scripts.UI
{
    public class RankingButton : MonoBehaviour
    {
        public void CallRanking()
        {
            var score = GameObject.Find("Canvas/ScoreUI").GetComponent<Score>().CurrentScore;
            naichilab.RankingLoader.Instance.SendScoreAndShowRanking (score);
        }
    }

}

