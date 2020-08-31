using System.Collections;
using System.Collections.Generic;
using Doozy.Engine.Utils.ColorModels;
using RAYSER.Scripts.Player;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class PresenterShield : MonoBehaviour
{
    [SerializeField]
    private Image imageComponent;
    
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Sprite[] shieldImages;
    
    void Start()
    {
        if (!player)
        {
            player = GameObject.Find("Player");
        }

        if (!imageComponent)
        {
            imageComponent = GetComponent<Image>();
        }

        var playerShield = player.GetComponent<PlayerShield>();
        playerShield.shield.Subscribe( x => { RefreshUI(x); }).AddTo(this);
    }

    // シールドUI更新
    void RefreshUI(int shield)
    {
        var index = shield;
        if (index < 0)
        {
            index = 0;
        }
        
        imageComponent.sprite = shieldImages[index];
        
    }
}
