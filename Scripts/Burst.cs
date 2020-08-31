using System.Collections;
using System.Collections.Generic;
using RAYSER.Scripts.Asteroid;
using RAYSER.Scripts.Enemy;
using UnityEngine;

public class Burst : MonoBehaviour
{
    [SerializeField]
    private Asteroid asteroid;

    [SerializeField] private float burstTime = 5.0f;
    void Start()
    {
        //3.5秒後に実行する
        StartCoroutine(DelayMethod(burstTime));
    }

    private IEnumerator DelayMethod(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        asteroid.AddDamage(9999);
        //gameObject.GetComponent<Enemy>().AddDamage(9999);
        
       
    }
    
}
