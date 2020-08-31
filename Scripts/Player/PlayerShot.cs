using System.Collections;
using System.Collections.Generic;
using RAYSER.Scripts.Bullet;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public GameObject laser;

    private AudioSource audioSource;

    [SerializeField] private float laserInterval = 0.5f;
    [SerializeField] private float laserIntervalCurrent = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Shot();
        }

        if (laserIntervalCurrent > 0)
        {
            LaserCoolDown();
        }
    }

    void Shot()
    {
        if (laserIntervalCurrent > 0)
        {
            return;
        }
        audioSource.Play();
        GameObject _laser = Instantiate(this.laser) as GameObject;
        _laser.GetComponent<Laser>().LaserShot(gameObject);
        laserIntervalCurrent = laserInterval;
    }

    void LaserCoolDown()
    {
        laserIntervalCurrent -= Time.deltaTime;
    }
}
