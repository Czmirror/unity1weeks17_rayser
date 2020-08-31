using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.Runtime.InteropServices;

namespace RAYSER.Scripts.UI
{

    public class TwitterButton : MonoBehaviour
    {

        public void Twitter()
        {
            var score = GameObject.Find("Canvas/ScoreUI").GetComponent<Score>().CurrentScore;

            var text = "RAYSER(V2) Score " + score + "\nhttps://unityroom.com/games/rayser_v2";
            var hashtag = "RAYSER";

            //urlの作成
            string esctext = UnityWebRequest.EscapeURL(text);
            string esctag = UnityWebRequest.EscapeURL(hashtag);
            string url = "https://twitter.com/intent/tweet?text=" + esctext + "&hashtags=" + esctag;

            //Twitter投稿画面の起動

#if UNITY_EDITOR
            Application.OpenURL(url);
#elif UNITY_WEBGL
            // WebGLの場合は、ゲームプレイ画面と同じウィンドウでツイート画面が開かないよう、処理を変える
            Application.ExternalEval(string.Format("window.open('{0}','_blank')", url));
#else
            Application.OpenURL(url);
#endif

        }
    }
}