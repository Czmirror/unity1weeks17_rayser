using System.Collections;
using System.Collections.Generic;
using RAYSER.Scripts.Player;
using UnityEngine;
using UniRx;

public class PresenterGameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!player)
        {
            player = GameObject.Find("Player");
        }
        
        var playerShield = player.GetComponent<PlayerShield>();
        playerShield.shield.Where(x => x == 0).Subscribe( x => { RefreshUI(); }).AddTo(this);
        
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void RefreshUI()
    {
        gameObject.SetActive(true);
    }
}
