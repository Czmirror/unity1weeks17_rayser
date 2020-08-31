using System.Collections;
using System.Collections.Generic;
using Doozy.Engine.Utils.ColorModels;
using RAYSER.Scripts.Player;
using UnityEngine;
using UniRx;

public class PlayerShieldEffect : MonoBehaviour
{
    private GameObject player;
    
    void Start()
    {
        player = transform.root.gameObject;
        var playershield = player.GetComponent<PlayerShield>();
        
        playershield.shieldActivate.Subscribe(x =>
        {
            ShieldActivate(x);
        }).AddTo(this);
        
        gameObject.SetActive(false);
    }

    void ShieldActivate(bool x)
    {
        if (x)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    
}
