using System.Collections;
using System.Collections.Generic;
using Doozy.Engine.Utils.ColorModels;
using RAYSER.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class PresenterScore : MonoBehaviour
{
    [SerializeField]
    private Score scoreClass;

    [SerializeField] private Text scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreClass.currentScore.Subscribe(x => RefreshUI(x));
    }

    void RefreshUI(int score)
    {
        
        scoreText.text = score.ToString();
    }
    
}
